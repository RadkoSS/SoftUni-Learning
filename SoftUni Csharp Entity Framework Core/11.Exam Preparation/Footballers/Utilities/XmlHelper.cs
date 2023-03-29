﻿namespace Footballers.Utilities;

using System.Text;
using System.Xml.Serialization;

public class XmlHelper
{
    public T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        using StringReader reader = new StringReader(inputXml);

        T deserializedDto = (T) xmlSerializer.Deserialize(reader);

        return deserializedDto;
    }

    public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

        using StringReader reader = new StringReader(inputXml);

        T[] deserializedDtos = (T[]) xmlSerializer.Deserialize(reader);

        return deserializedDtos;
    }

    // Serialize<ExportDto>(ExportDto, rootName)
    public string Serialize<T>(T obj, string rootName)
    {
        StringBuilder sb = new StringBuilder();

        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

        namespaces.Add(string.Empty, string.Empty);

        using StringWriter writer = new StringWriter(sb);

        xmlSerializer.Serialize(writer, obj, namespaces);

        return sb.ToString().TrimEnd();
    }

    // Serialize<ExportDto>(ExportDto[], rootName)
    public string Serialize<T>(T[] obj, string rootName)
    {
        StringBuilder sb = new StringBuilder();

        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

        namespaces.Add(string.Empty, string.Empty);

        using StringWriter writer = new StringWriter(sb);

        xmlSerializer.Serialize(writer, obj, namespaces);

        return sb.ToString().TrimEnd();
    }
}