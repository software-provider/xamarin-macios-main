#nullable enable

namespace ModelIO {
	public partial class MDLAsset {
		public MDLMaterialProperty this [nuint index] {
			get {
				return ObjectAtIndexedSubscript (index);
			}
		}

		public MDLMaterialProperty this [string name] {
			get {
				return ObjectForKeyedSubscript (name);
			}
		}
	}
}
