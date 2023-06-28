using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Xamarin.iOS.Tasks {
	public class DataSet {
		[JsonProperty ("data")]
		public IEnumerable<DataItem> DataItems { get; set; }

#pragma warning disable 0169 // warning CS0169: The field 'DataSet.JsonData' is never used
		//This stores the properties we don't need to deserialize but exist, just to avoid loosing information
		[JsonExtensionData]
		IDictionary<string, JToken> JsonData;
#pragma warning restore 0169
	}
}
