using System;
using Xunit;
using Serializer;
using Deserializer;
using System.IO;
public class TestClass
{
	SerializerApp serializerApp = new SerializerApp();
	DeserializerApp deserializerApp = new DeserializerApp();

	//tests serialize
	[Fact]
	public void SerializeTest()
	{
		Assert.Equal(1, serializerApp.Serialize());
	}

	//tests deserialize
	[Fact]
	public void DeserializeTest()
	{
		Assert.Equal(1, deserializerApp.Deserialize());
	}

}
