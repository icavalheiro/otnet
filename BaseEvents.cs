using System;

namespace OTNet
{

    //TODO: check if we can merge this into a base event
    class Event
{

	public:
		explicit Event(LuaScriptInterface* interface);
		virtual ~Event() = default;

		virtual bool configureEvent(const pugi::xml_node& node) = 0;

		bool Event::checkScript(const std::string& basePath, const std::string& scriptsName, const std::string& scriptFile) const
{
	LuaScriptInterface* testInterface = g_luaEnvironment.getTestInterface();
	testInterface->reInitState();

	if (testInterface->loadFile(std::string(basePath + "lib/" + scriptsName + ".lua")) == -1) {
		std::cout << "[Warning - Event::checkScript] Can not load " << scriptsName << " lib/" << scriptsName << ".lua" << std::endl;
	}

	if (scriptId != 0) {
		std::cout << "[Failure - Event::checkScript] scriptid = " << scriptId << std::endl;
		return false;
	}

	if (testInterface->loadFile(basePath + scriptFile) == -1) {
		std::cout << "[Warning - Event::checkScript] Can not load script: " << scriptFile << std::endl;
		std::cout << testInterface->getLastLuaError() << std::endl;
		return false;
	}

	int32_t id = testInterface->getEvent(getScriptEventName());
	if (id == -1) {
		std::cout << "[Warning - Event::checkScript] Event " << getScriptEventName() << " not found. " << scriptFile << std::endl;
		return false;
	}
	return true;
}

bool Event::loadScript(const std::string& scriptFile)
{
	if (!scriptInterface || scriptId != 0) {
		std::cout << "Failure: [Event::loadScript] scriptInterface == nullptr. scriptid = " << scriptId << std::endl;
		return false;
	}

	if (scriptInterface->loadFile(scriptFile) == -1) {
		std::cout << "[Warning - Event::loadScript] Can not load script. " << scriptFile << std::endl;
		std::cout << scriptInterface->getLastLuaError() << std::endl;
		return false;
	}

	int32_t id = scriptInterface->getEvent(getScriptEventName());
	if (id == -1) {
		std::cout << "[Warning - Event::loadScript] Event " << getScriptEventName() << " not found. " << scriptFile << std::endl;
		return false;
	}

	scripted = true;
	scriptId = id;
	return true;
}
		virtual bool loadFunction(const pugi::xml_attribute&) {
			return false;
		}

		bool isScripted() const {
			return scripted;
		}

	protected:
		virtual std::string getScriptEventName() const = 0;

		bool scripted = false;
		int32_t scriptId = 0;
		LuaScriptInterface* scriptInterface = nullptr;
};

class BaseEvents
{
	public:
 		constexpr BaseEvents() = default;
		virtual ~BaseEvents() = default;

		bool BaseEvents::loadFromXml()
{
	if (loaded) {
		std::cout << "[Error - BaseEvents::loadFromXml] It's already loaded." << std::endl;
		return false;
	}

	std::string scriptsName = getScriptBaseName();
	std::string basePath = "data/" + scriptsName + "/";
	if (getScriptInterface().loadFile(basePath + "lib/" + scriptsName + ".lua") == -1) {
		std::cout << "[Warning - BaseEvents::loadFromXml] Can not load " << scriptsName << " lib/" << scriptsName << ".lua" << std::endl;
	}

	std::string filename = basePath + scriptsName + ".xml";

	pugi::xml_document doc;
	pugi::xml_parse_result result = doc.load_file(filename.c_str());
	if (!result) {
		printXMLError("Error - BaseEvents::loadFromXml", filename, result);
		return false;
	}

	loaded = true;

	for (auto node : doc.child(scriptsName.c_str()).children()) {
		Event* event = getEvent(node.name());
		if (!event) {
			continue;
		}

		if (!event->configureEvent(node)) {
			std::cout << "[Warning - BaseEvents::loadFromXml] Failed to configure event" << std::endl;
			delete event;
			continue;
		}

		bool success;

		pugi::xml_attribute scriptAttribute = node.attribute("script");
		if (scriptAttribute) {
			std::string scriptFile = "scripts/" + std::string(scriptAttribute.as_string());
			success = event->checkScript(basePath, scriptsName, scriptFile) && event->loadScript(basePath + scriptFile);
		} else {
			success = event->loadFunction(node.attribute("function"));
		}

		if (!success || !registerEvent(event, node)) {
			delete event;
		}
	}
	return true;
}

bool BaseEvents::reload()
{
	loaded = false;
	clear();
	return loadFromXml();
}
		bool isLoaded() const {
			return loaded;
		}

	private:
		virtual LuaScriptInterface& getScriptInterface() = 0;
		virtual std::string getScriptBaseName() const = 0;
		virtual Event* getEvent(const std::string& nodeName) = 0;
		virtual bool registerEvent(Event* event, const pugi::xml_node& node) = 0;
		virtual void clear() = 0;

		bool loaded = false;
};

//TODO: merge into basevents or move it into DataTypes
class CallBack
{
	public:
		CallBack() = default;

		bool CallBack::loadCallBack(LuaScriptInterface* interface, const std::string& name)
{
	if (!interface) {
		std::cout << "Failure: [CallBack::loadCallBack] scriptInterface == nullptr" << std::endl;
		return false;
	}

	scriptInterface = interface;

	int32_t id = scriptInterface->getEvent(name.c_str());
	if (id == -1) {
		std::cout << "[Warning - CallBack::loadCallBack] Event " << name << " not found." << std::endl;
		return false;
	}

	scriptId = id;
	loaded = true;
	return true;
}

	protected:
		int32_t scriptId = 0;
		LuaScriptInterface* scriptInterface = nullptr;

	private:
		bool loaded = false;
};
    
}