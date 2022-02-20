# PowerXtensions.DotNet
A collection of extensions to be used in .Net

## String Extensions

- [AllCharactersSame](#AllCharactersSame)
- [Base64Encode](#Base64Encode)
- [Base64Decode](#Base64Decode)
- HexadecimalEncode
- HexadecimalDecode
- ToDateTime
- ToNullableDateTime
- ToInt
- ToNullableInt
- ToLong
- ToNullableLong
- ToShort
- ToNullableShort
- Contains
- HasMoreThanOneWord
- IsNullOrEmptyOrWhiteSpace
- OnlyNumbers
- Remove

&nbsp;

---

&nbsp;

### AllCharactersSame
#### In this extension, the check is made if all the characters present are the same.

&nbsp;

```C#
public void test()
{
    var str = "1111111";

    if (str.AllCharactersSame())
    {
        //todo
    }
    else
    {
        //todo
    }
}
```

&nbsp;

### Base64Encode
#### In this extension it is possible to convert a String (plain text) to a String (Base64).

&nbsp;

```C#
public void test()
{
    var str = "1111111";

    var strBase64 = str.Base64Encode();

    Console.WriteLine(strBase64);
    // MTExMTExMQ==
}
```

&nbsp;

### Base64Decode
#### In this extension it is possible to convert a String (Base64) to a String (plain text)

&nbsp;

```C#
public void test()
{
    var strBase64 = "MTExMTExMQ==";

    var str = strBase64.Base64Decode();

    Console.WriteLine(str);
    // 1111111
}
```