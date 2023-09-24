

Dicionario<int, string> dic = new Dicionario<int,string>(4);

if(args.Length > 0)
{
    for(int i = 0; i < args.Length; i++)
    {
        switch (args[i])
        {
        
        }
    }
}


public class Dicionario<Tchave, Tvalor>
{
    public Tchave[] chaves;
    public Tvalor[] valores;
    public int contador;

    public Dicionario(int tamanho)
    {
        chaves = new Tchave[tamanho];
        valores = new Tvalor[tamanho];
        contador = 0;
    }

    public void Adicionar(Tchave chave,Tvalor valor)
    {
        int indice = Pesquisar(chave);
        if(indice == -1 && contador < chaves.Length)
        {
            chaves[contador] = chave;
            valores[contador] = valor;
            contador++;
        }
        else
        {
            throw new Exception("ERRO");
        }
    }
    public int Pesquisar(Tchave chave)
    {
        for(int i = 0;i < chaves.Length; i++)
        {
            if (chaves[i] == chave)
            {
                return i;
            }
        }
        return -1;
    }
    public Tvalor Remover(Tchave chave)
    {
        int indice = Pesquisar(chave);
        Tvalor res;
        if(indice != -1)
        {
            res = valores[indice];
            for(int i = indice; i < chaves.Length; i++)
            {
                chaves[i] = chaves[i + 1];
                valores[i] = valores[i + 1];
            }
            contador--;
        }
        else
        {
            throw new Exception();
        }
        return res;
    }
    public void Atualiza(Tchave chave,Tvalor valor)
    {
        int indice = Pesquisar(chave);
        if(indice != -1)
        {
            valores[indice] = valor;
        }
        else
        {
            throw new Exception();
        }
    }
}