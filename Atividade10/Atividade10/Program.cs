/*      Polimorfismo é um conceito fundamental em programação orientada a objetos que permite que uma única interface (ou método) possa ter diferentes comportamentos
dependendo do tipo do objeto que a utiliza. Em outras palavras, o mesmo nome de método pode se comportar de maneiras diferentes em diferentes classes.



Tipos de Polimorfismo: Polimorfismo de Subtipo (ou Inclusivo), que é o de sobreposição, ou mais conhecido como "Overriding".

Polimorfismo de Sobrecarga(Overloading) um método na classe base pode ser substituído por um método com o mesmo nome e assinatura na classe derivada.

Polimorfismo Paramétrico: Generics: Em algumas linguagens, como Java e C#, você pode usar generics para criar classes, interfaces e métodos que operam sobre tipos genéricos.
Isso permite que você escreva código que pode trabalhar com diferentes tipos de dados sem perder a segurança de tipo.

Seus pontos positivos são: Extensibilidade e Manutenção; Redução de Código Duplicado ; Implementação de Algoritmos Genéricos e Facilita a Interoperabilidade.


    Apesar disso, nem tudo são flores, ele possui alguns problemas, como por exemplo: Complexidade Adicional, Desempenho, Sobrecarga de Memória, Problemas de Design,
Herança e Polimorfismo, Abstração Excessiva.


*/


using System;

public class Animal
{
    public virtual void FazerSom()
    {
        Console.WriteLine("O animal faz um som.");
    }
}

public class Cachorro : Animal
{
    public override void FazerSom()
    {
        Console.WriteLine("O cachorro late.");
    }
}

public class Gato : Animal
{
    public override void FazerSom()
    {
        Console.WriteLine("O gato mia.");
    }
}

class Program
{
    static void Main()
    {
        Animal meuAnimal = new Animal();
        Animal meuCachorro = new Cachorro();
        Animal meuGato = new Gato();
        
        meuAnimal.FazerSom(); 
        meuCachorro.FazerSom();
        meuGato.FazerSom();
    }
}