using System;
using MsgSize = System.UInt16;
using OTNet.Const;
using System.Runtime.InteropServices;

namespace OTNet{

    //TODO: convert this to work with streams instead of local buffers
    public class NetworkMessage
    {
        protected class NetworkMessageInfo {
            public MsgSize Length = 0;
            public MsgSize Position = NetworkMessage.INITIAL_BUFFER_POSITION;
            public bool Overrun = false;
        }

        #region public data
        // Headers:
		// 2 bytes for unencrypted message size
		// 4 bytes for checksum
		// 2 bytes for encrypted message size
        public const MsgSize INITIAL_BUFFER_POSITION = 9;
        public const int HEADER_LENGTH = 2;
        public const int CHECKSUM_LENGTH = 4;
        public const int XTEA_MULTIPLE = 8;
        public const int MAX_BODY_LENGTH = Constants.NETWORKMESSAGE_MAXSIZE - HEADER_LENGTH - CHECKSUM_LENGTH - XTEA_MULTIPLE;
        public const int MAX_PROTOCOL_BODY_LENGTH = MAX_BODY_LENGTH - 10;
        
        
        
        #endregion

        #region protected data
        protected NetworkMessageInfo _info = new NetworkMessageInfo();
        protected byte[] _buffer = new byte[Constants.NETWORKMESSAGE_MAXSIZE];
        #endregion

        public MsgSize GetLength(){
            return _info.Length;
        }

        public void SetLength(MsgSize newLength){
            _info.Length = newLength;
        }

        public MsgSize GetBufferPosition(){
            return _info.Position;
        }

        public MsgSize GetLengthHeader(){
            return (MsgSize)(_buffer[0] | _buffer[1] << 8);
        }

        public MsgSize DecodeHeader(){
            MsgSize newSize = GetLengthHeader();
            _info.Length = newSize;
            return _info.Length;
        }

        public bool IsOverrun(){
            return _info.Overrun;
        }

        public byte[] GetBuffer(){
            return _buffer;
        }

        public MsgSize GetBodyBufferPosition(){
            _info.Position = HEADER_LENGTH;
            return HEADER_LENGTH;
        }

        [Obsolete("Use GetBuffer and GetBodyBufferPosition to ge the start position of the body in the buffer")]
        public byte GetBodyBuffer(){
            throw new Exception("OBSOLETE");
        }

        public byte GetByte(){
            if(!CanRead(1)){
                return 0;
            }

            return _buffer[_info.Position++];
        }

        public byte GetPreviousByte(){
            return _buffer[--_info.Position];
        }

        // public byte Get(){
        //     return 
        // }

        // public T Get<T> (){
        //     if(!CanRead(Marshal.SizeOf(typeof(T)))){
        //         return (T)0;
        //     }
        // }

        public void Reset(){
            _info = new NetworkMessageInfo();
        }

        private bool CanRead(Int32 size){
            if((_info.Position + size) > (_info.Length + 8) || size >= (Constants.NETWORKMESSAGE_MAXSIZE - _info.Position)){
                _info.Overrun = true;
                return false;
            }

            return true;
        }

        private bool CanAdd(Int32 size){
            return (size + _info.Position) < MAX_BODY_LENGTH;
        }


// 	public:
// 		// Headers:
// 		// 2 bytes for unencrypted message size
// 		// 4 bytes for checksum
// 		// 2 bytes for encrypted message size
// 		static constexpr MsgSize_t INITIAL_BUFFER_POSITION = 8;
// 		enum { HEADER_LENGTH = 2 };
// 		enum { CHECKSUM_LENGTH = 4 };
// 		enum { XTEA_MULTIPLE = 8 };
// 		enum { MAX_BODY_LENGTH = NETWORKMESSAGE_MAXSIZE - HEADER_LENGTH - CHECKSUM_LENGTH - XTEA_MULTIPLE };
// 		enum { MAX_PROTOCOL_BODY_LENGTH = MAX_BODY_LENGTH - 10 };

// 		NetworkMessage() = default;

// 		void reset() {
// 			info = {};
// 		}

// 		// simply read functions for incoming message
// 		uint8_t getByte() {
// 			if (!canRead(1)) {
// 				return 0;
// 			}

// 			return buffer[info.position++];
// 		}

// 		uint8_t getPreviousByte() {
// 			return buffer[--info.position];
// 		}

// 		template<typename T>
// 		T get() {
// 			if (!canRead(sizeof(T))) {
// 				return 0;
// 			}

// 			T v;
// 			memcpy(&v, buffer + info.position, sizeof(T));
// 			info.position += sizeof(T);
// 			return v;
// 		}

// 		std::string getString(uint16_t stringLen = 0);
// 		Position getPosition();

// 		// skips count unknown/unused bytes in an incoming message
// 		void skipBytes(int16_t count) {
// 			info.position += count;
// 		}

// 		// simply write functions for outgoing message
// 		void addByte(uint8_t value) {
// 			if (!canAdd(1)) {
// 				return;
// 			}

// 			buffer[info.position++] = value;
// 			info.length++;
// 		}

// 		template<typename T>
// 		void add(T value) {
// 			if (!canAdd(sizeof(T))) {
// 				return;
// 			}

// 			memcpy(buffer + info.position, &value, sizeof(T));
// 			info.position += sizeof(T);
// 			info.length += sizeof(T);
// 		}

// 		void addBytes(const char* bytes, size_t size);
// 		void addPaddingBytes(size_t n);

// 		void addString(const std::string& value);

// 		void addDouble(double value, uint8_t precision = 2);

// 		// write functions for complex types
// 		void addPosition(const Position& pos);
// 		void addItem(uint16_t id, uint8_t count);
// 		void addItem(const Item* item);
// 		void addItemId(uint16_t itemId);

// 		MsgSize_t getLength() const {
// 			return info.length;
// 		}

// 		void setLength(MsgSize_t newLength) {
// 			info.length = newLength;
// 		}

// 		MsgSize_t getBufferPosition() const {
// 			return info.position;
// 		}

// 		uint16_t getLengthHeader() const {
// 			return static_cast<uint16_t>(buffer[0] | buffer[1] << 8);
// 		}

// 		int32_t decodeHeader();

// 		bool isOverrun() const {
// 			return info.overrun;
// 		}

// 		uint8_t* getBuffer() {
// 			return buffer;
// 		}

// 		const uint8_t* getBuffer() const {
// 			return buffer;
// 		}

// 		uint8_t* getBodyBuffer() {
// 			info.position = 2;
// 			return buffer + HEADER_LENGTH;
// 		}

// 	protected:
// 		struct NetworkMessageInfo {
// 			MsgSize_t length = 0;
// 			MsgSize_t position = INITIAL_BUFFER_POSITION;
// 			bool overrun = false;
// 		};

// 		NetworkMessageInfo info;
// 		uint8_t buffer[NETWORKMESSAGE_MAXSIZE];

// 	private:
// 		bool canAdd(size_t size) const {
// 			return (size + info.position) < MAX_BODY_LENGTH;
// 		}

// 		bool canRead(int32_t size) {
// 			if ((info.position + size) > (info.length + 8) || size >= (NETWORKMESSAGE_MAXSIZE - info.position)) {
// 				info.overrun = true;
// 				return false;
// 			}
// 			return true;
// 		}
    };
}