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

### AllCharactersSame
#### [EN] In this extension, the check is made if all the characters present are the same.
#### [PT-BR] Nesta extensão, a verificação é feita se todos os caracteres presentes são iguais.

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

```C#
public void test()
{
    var str = "PowerXtensions to .Net written with C#";

    Console.WriteLine(str.HexadecimalEncode())
    // 506f7765725874656e73696f6e7320746f202e4e6574207772697474656e2077697468204323
}
```

&nbsp;

### IsNullOrEmptyOrWhiteSpace
#### [EN] In this extension, it checks if the String is null, empty or contains white space.
#### [PT-BR] Nesta extensão, verifica se a String é nula, vazia ou contém espaços em branco.

```C#
public void test()
{
    var str = "";

    if (str.IsNullOrEmptyOrWhiteSpace())
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

### OnlyNumbers
#### [EN] In this extension, removes all non-numeric characters.
#### [PT-BR] Nesta extensão, remove todos os caracteres não numéricos.

```C#
public void test()
{
    var str = "PowerXtensions to .Net written with C# 1234567890";

    Console.WriteLine(str.OnlyNumbers());
    // 123456789
}
```

&nbsp;

### Remove
#### [EN] In this extension, removes the informed text from the String.
#### [PT-BR] Nesta extensão, remove o texto informado da String.

```C#
public void test()
{
    var str = "PowerXtensions to .Net written with C# 1234567890";
    str = str.Remove(" 1234567890");

    Console.WriteLine(str);
    // PowerXtensions to .Net written with C#
}
```

&nbsp;

### ToDateTime
#### [EN] In this extension, converts the String to a DateTime. If unable to convert an exception will be thrown.
#### [PT-BR] Nesta extensão, converte a String em um DateTime. Se não for possível converter uma exceção será lançada.

```C#
public void test()
{
    var str = "31/12/2000 23:59:29";
    DateTime dt = str.ToDateTime("dd/MM/yyyy HH:mm:ss");
    // if not pass format, default will be assigned yyyy-MM-dd
}
```

&nbsp;

### ToInt
#### [EN] In this extension, converts the String to a Integer. If unable to convert an exception will be thrown.
#### [PT-BR] Nesta extensão, converte a String em um Inteiro. Se não for possível converter uma exceção será lançada.

```C#
public void test()
{
    var str = "123456";
    int dt = str.ToInt();
    // 123456
}
```

&nbsp;

### ToLong
#### [EN] In this extension, converts the String to a Long. If unable to convert an exception will be thrown.
#### [PT-BR] Nesta extensão, converte a String em um Longo. Se não for possível converter uma exceção será lançada.

```C#
public void test()
{
    var str = "1234567890";
    long dt = str.ToLong();
    // 1234567890
}
```

&nbsp;

### ToShort
#### [EN] In this extension, converts the String to a Short. If unable to convert an exception will be thrown.
#### [PT-BR] Nesta extensão, converte a String em um Curto. Se não for possível converter uma exceção será lançada.

```C#
public void test()
{
    var str = "123";
    short dt = str.ToShort();
    // 123
}
```

&nbsp;

### ToNullableDateTime
#### [EN] In this extension, converts the String to a Nullable DateTime. If unable to convert, a null Nullable DateTime is returned.
#### [PT-BR] Nesta extensão, converte a String em um "Nullable DateTime". Se não puder converter, um "Nullable DateTime" nulo é retornado.

```C#
public void test()
{
    var str = "31/12/2000 23:59:29";
    DateTime dt? = str.ToNullableDateTime("dd/MM/yyyy HH:mm:ss");
    // if not pass format, default will be assigned yyyy-MM-dd
}
```

&nbsp;

### ToNullableInt
#### [EN] In this extension, converts the String to a Nullable Integer. If unable to convert, a null Nullable Integer is returned.
#### [PT-BR] Nesta extensão, converte a String em um "Nullable Inteiro". Se não puder converter, um "Nullable Inteiro" nulo é retornado.

```C#
public void test()
{
    var str = "123456";
    int? dt = str.ToNullableInt();
    // 123456
}
```

&nbsp;

### ToNullableLong
#### [EN] In this extension, converts the String to a Nullable Long. If unable to convert, a null Nullable Long is returned.
#### [PT-BR] Nesta extensão, converte a String em um "Nullable Longo". Se não puder converter, um "Nullable Longo" nulo é retornado.

```C#
public void test()
{
    var str = "1234567890";
    long? dt = str.ToNullableLong();
    // 1234567890
}
```

&nbsp;

### ToNullableShort
#### [EN] In this extension, converts the String to a Nullable Short. If unable to convert, a null Nullable Short is returned.
#### [PT-BR] Nesta extensão, converte a String em um "Nullable Short". Se não puder converter, um "Nullable Short" nulo é retornado.

```C#
public void test()
{
    var str = "123";
    short? dt = str.ToNullableShort();
    // 123
}
```