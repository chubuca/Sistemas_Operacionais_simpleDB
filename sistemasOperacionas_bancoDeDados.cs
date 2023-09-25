using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO
Dicionario<int,string> db;

#region File Mangement

    string fileName = "DataBase.json";


    void Write(Dicionario<int, string> dicionario, string fileName)
    {
        string serializeString = JsonSerializer.Serialize(dicionario);
        File.WriteAllText(fileName, serializeString);
    }

    Dicionario<int, string> Read(string fileName)
    {
        string desserializedString = File.ReadAllText(fileName);
        Dicionario<int, string> dicionario = JsonSerializer.Deserialize<Dicionario<int, string>>(desserializedString);
        return dicionario;
    }

#endregion

#region Runtime Behaviour

if(args.lenght > 0)
{
    for(int i = 1;i < args.lenght - 2; i++)
    {
        switch (args[i])
        {
            case "-cache": db = new Dicionario<int, string>(args[i+1]);i++; break;
            case "--insert": db.Adicionar(i+1,i+2);i+=2;break;
            case "--remove": db.Remover(i+1);i++;break;
            case "--search": if(db.Pesquisar(i+1) != -1) { Console.WriteLine(vlores[db.Pesquisar(i + 1)] ; } i + 1; break;
            case "--update": db.Atualiza(i+1,i+2);i+=2; break;
        }
    }
}


#endregion

#region Custom Classes
    public class Dicionario<Tchave, Tvalor>{
        private Tchave[] _chaves;
        private Tvalor[] _valores;
        private int _contador;

        public Tchave[] chaves{
            get {return _chaves;}
            set {_chaves = value;}
        }

        public Tvalor[] valores{
            get {return _valores;}
            set {_valores = value;}
        }

        public int contador{
            get {return _contador;}
            set {_contador = value;}
        }

        public Dicionario(){}

        public Dicionario(int tamanho){
            chaves = new Tchave[tamanho];
            valores = new Tvalor[tamanho];
            contador = 0;
        }

        public void Adicionar(Tchave chave,Tvalor valor){
            int indice = Pesquisar(chave);
            if(indice == -1 && contador < chaves.Length){
                chaves[contador] = chave;
                valores[contador] = valor;
                contador++;
            }
        }
        public int Pesquisar(Tchave chave){
            for(int i = 0;i < chaves.Length; i++){
                if (chaves[i].Equals(chave)){
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

#endregion
