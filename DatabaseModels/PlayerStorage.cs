using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class PlayerStorage
    {
        public int PlayerId { get; set; }
        public uint Key { get; set; }
        public int Value { get; set; }

        public Players Player { get; set; }
    }
}
