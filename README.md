# PowerXtensions.DotNet
#### [EN] PowerXtensions.DotNet, as its name suggests, is a collection of extensions to be used in the .Net environment. These are extensions that were frequently rewritten in several projects and that's why I decided to make them public.
#### [PT-BR] PowerXtensions.DotNet, como o próprio nome sugere, é uma coleção de extensões para serem usadas no ambiente .Net. São extensões que frequentemente eram reescritas em diversos projetos e por isso decidi deixa-las publicas.

## String Extensions

- [AllCharactersSame](#AllCharactersSame)
- [Base64Decode](#Base64Decode)
- [Base64Encode](#Base64Encode)
- [Contains](#Contains)
- [HasMoreThanOneWord](#HasMoreThanOneWord)
- [HexadecimalDecode](#HexadecimalDecode)
- [HexadecimalEncode](#HexadecimalEncode)
- [IsNullOrEmptyOrWhiteSpace](#IsNullOrEmptyOrWhiteSpace)
- [OnlyNumbers](#OnlyNumbers)
- [Remove](#Remove)
- [ToDateTime](#ToDateTime)
- [ToInt](#ToInt)
- [ToLong](#ToLong)
- [ToShort](#ToShort)
- [ToNullableDateTime](#ToNullableDateTime)
- [ToNullableInt](#ToNullableInt)
- [ToNullableLong](#ToNullableLong)
- [ToNullableShort](#ToNullableShort)

&nbsp;

---

&nbsp;

### AllCharactersSame
#### [EN] In this extension, the check is made if all the characters present are the same.
#### [PT-BR] Nesta extensão, a verificação é feita se todos os caracteres presentes são iguais.

&nbsp;

```C#
public void test()
{
    var str = "1111111";

    if (str.AllCharactersSame())
    {
        // TODO
    }
    else
    {
        // TODO
    }
}
```

&nbsp;

### Base64Decode
#### [EN] In this extension it is possible to convert a String (Base64) to a String (plain text).
#### [PT-BR] Nesta extensão é possível converter uma String (Base64) para uma String (texto simples).

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

&nbsp;

### Base64Encode
#### [EM] In this extension it is possible to convert a String (plain text) to a String (Base64).
#### [PT-BR] Nesta extensão é possível converter uma String (texto simples) para uma String (Base64).

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

### Contains
#### [EN] In this extension, it checks if any of the informed items exists in the String.
#### [PT-BR] Nesta extensão, verifica se algum dos itens informados existe na String.

&nbsp;

```C#
public void test()
{
    var str = "PowerXtensions to .Net written with C#";

    if (str.Contains(".Net", "C#", "VB.Net"))
    {
        // TODO
    }
    else
    {
        // TODO
    }
}
```

&nbsp;

### HasMoreThanOneWord
#### [EN] In this extension, it checks if there is more than one word in the String.
#### [PT-BR] Nesta extensão, verifica se há mais de uma palavra na String.

&nbsp;

```C#
public void test()
{
    var str = "PowerXtensions to .Net written with C#";

    if (str.HasMoreThanOneWord())
    {
        // TODO
    }
    else
    {
        // TODO
    }
}
```

&nbsp;

### HexadecimalDecode
#### [EN] In this extension, converts a Hexadecimal to String (Plain Text).
#### [PT-BR] Nesta extensão, converte um Hexadecimal para String (Texto Simples).

&nbsp;

```C#
public void test()
{
    var strHexadecimal = "506f7765725874656e73696f6e7320746f202e4e6574207772697474656e2077697468204323";

    Console.WriteLine(strHexadecimal.HexadecimalDecode())
    // PowerXtensions to .Net written with C#
}
```

&nbsp;

### HexadecimalEncode
#### [EN] In this extension, converts a String (Plain Text) to Hexadecimal.
#### [PT-BR] Nesta extensão, converte uma String (Texto Simples) para Hexadecimal.

&nbsp;

```C#
public void test()
{
    var str = "PowerXtensions to .Net written with C#";

    Console.WriteLine(str.HexadecimalEncode())
    // 506f7765725874656e73696f6e7320746f202e4e6574207772697474656e2077697468204323
}
```