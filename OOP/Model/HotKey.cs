using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OOP.Model
{
	class HotKey: ConfigurationSection
	{
		[ConfigurationProperty("nextpage")]
		public Element NextPage => (Element)base["nextpage"];
		[ConfigurationProperty("prevpage")]
		public Element PrevPage => (Element)base["prevpage"];
		[ConfigurationProperty("lastpage")]
		public Element LastPage => (Element)base["lastpage"];
		[ConfigurationProperty("firstpage")]
		public Element FirstPage => (Element)base["firstpage"];
	}

	class Element: ConfigurationElement
	{
		[ConfigurationProperty("Key")]
        public string Key
		{
			get => (string)base["Key"];
			set => base["Key"] = value;
		}

	}
}
