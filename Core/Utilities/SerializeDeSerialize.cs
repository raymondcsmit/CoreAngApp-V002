using Newtonsoft.Json;

namespace Core.Utilities
{
	public static class SerializeDeSerialize
	{
		public static string SerializeObject(object obj)
		{
			return JsonConvert.SerializeObject(obj);
		}

		public static T DeserializeObject<T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}
	}
}
