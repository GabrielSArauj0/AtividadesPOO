/*O código fornecido funciona porque, embora a classe abstrata Poligono não possa ser instanciada diretamente, o array Poligono[] não cria instâncias de Poligono.
Ele apenas cria um array de referências para objetos do tipo Poligono ou de classes que estendem Poligono. 
Em Java, é permitido criar arrays de classes abstratas ou interfaces, pois o array em si não contém instâncias, apenas referências.*/

using System;

class Program
{
    static void Main(string[] args)
    {
        
        Poligono[] poligonos = new Poligono[2];

        
        poligonos[0] = new Triangulo();
        poligonos[1] = new Quadrado();

       
        foreach (Poligono p in poligonos)
        {
            p.Desenhar();
        }
    }
}

public abstract class Poligono
{
    public abstract void Desenhar();
}

public class Triangulo : Poligono
{
    public override void Desenhar()
    {
        Console.WriteLine("Desenhando um Triângulo.");
    }
}

public class Quadrado : Poligono
{
    public override void Desenhar()
    {
        Console.WriteLine("Desenhando um Quadrado.");
    }
}