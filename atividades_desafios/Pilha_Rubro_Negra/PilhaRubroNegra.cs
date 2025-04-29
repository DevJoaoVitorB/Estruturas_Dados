using System;

public class PilhaRubroNegra<T> : Pilha<T>
{
	private int TopoR;						// Atributo do topo vermelho da pilha			
	private int TopoN;						// Atributo do topo preto da pilha
	private int Capacidade;					// Atributo da capacidade da pilha
	private int FC;							// Atributo do fator de crescimento da pilha
	private T[] PilhaArray;					// PilhaArray
	
	public PilhaRubroNegra(int capacidade, int crescimento)
	{
		Capacidade = capacidade;			// Definindo a capacidade da PilhaArray
		
		if(crescimento<=0) FC = 0;			// Redirecionamento de capacidade Duplicativo
		else FC = crescimento;				// Redirecionamento de capacidade Incremental
		
		PilhaArray = new T[Capacidade];		// Criação da PilhaArray
		
		TopoR = -1;							// Definição do topo vermelho
		TopoN = Capacidade;					// Definição do topo preto
	}
	
	public void AumentarCapacidade()
	{
		if(TopoR==TopoN - 1)										// Verificação da capacidade da PilhaArray (TRUE = Cheia, FALSE = Livre)
		{
			int indiceCapacidadeAntiga = Capacidade - 1;			// Variavel auxiliar do índice máximo da capacidade antiga
			
			if(FC==0) Capacidade *= 2;								// Estratégia Duplicativa
			else Capacidade += FC;									// Estratégia Incremental
			
			int indiceCapacidadeNova = Capacidade - 1;				// Variavel auxiliar do índice máximo da capacidade nova
	
			T[] arrayTemp = new T[Capacidade];						// Criação da PilhaArray auxiliar temporária
			
			for(int i = 0; i <= TopoR; i++)					
			{
				arrayTemp[i] = PilhaArray[i];						// Transferindo elementos vermelhos para a PilhaArray auxiliar
			}
			
			for(int j = indiceCapacidadeAntiga; j >= TopoN; j--)
			{
				arrayTemp[indiceCapacidadeNova] = PilhaArray[j];	// Transferindo elementos pretos para a PilhaArray auxiliar
				indiceCapacidadeNova--;
			}

			TopoN = indiceCapacidadeNova + 1;						// Novo topo preto para a PilhaArray
			
			PilhaArray = arrayTemp;									// PilhaArray temporária passa a ser a PilhaArray principal
		}
	}
	
	public void PushVermelho(T objeto)
	{	
		AumentarCapacidade();										// Verifica a capacidade antes do push do elemento vermelho
		PilhaArray[++TopoR] = objeto;								// Adiciona o elemento vermelho na PilhaArray
	}
	
	public void PushPreto(T objeto)
	{
		AumentarCapacidade();										// Verifica a capacidade antes do push do elemento preto
		PilhaArray[--TopoN] = objeto;								// Adiciona o elemento preto na PilhaArray
	}

	public void ReduzirCapacidade()
    {
        if(Size() <= Capacidade/3)									// Verificação da capacidade da PilhaArray (TRUE = Abaixo da Capacidade Esperada, FALSE = Capacidade Esperada)
        {
            int indiceCapacidadeAntiga = Capacidade - 1;			// Variavel auxiliar do índice máximo da capacidade antiga

            Capacidade /= 2;										// Redução da capacidade da PilhaArray pela metade

            int indiceCapacidadeNova = Capacidade - 1;				// Variavel auxiliar do índice máximo da capacidade nova

			T[] arrayTemp = new T[Capacidade];						// Criação da PilhaArray auxiliar temporária
			
			for(int i = 0; i <= TopoR; i++)
			{
				arrayTemp[i] = PilhaArray[i];						// Transferindo elementos vermelhos para a PilhaArray auxiliar
			}
			
			for(int j = indiceCapacidadeAntiga; j >= TopoN; j--)
			{
				arrayTemp[indiceCapacidadeNova] = PilhaArray[j];	// Transferindo elementos pretos para a PilhaArray auxiliar
				indiceCapacidadeNova--;
			}

			TopoN = indiceCapacidadeNova + 1;						// Novo topo preto para a PilhaArray
			
			PilhaArray = arrayTemp;									// PilhaArray temporária passa a ser a PilhaArray principal
        }
    }
	
	public T PopVermelho()
	{
		IsEmptyVermelho();											// Verifica se o lado vermelho da PilhaArray está vazio
        ReduzirCapacidade();										// Verifica a capacidade antes do pop do elemento vermelho
		T removido = PilhaArray[TopoR--];							// Remoção e armazenamento do elemento vermelho removido
		return removido;											// Retorno do elemento vermelho removido
	}
	
	public T PopPreto()
	{
		IsEmptyPreto();												// Verifica se o lado preto da PilhaArray está vazio
        ReduzirCapacidade();										// Verifica a capacidade antes do pop do elemento preto
		T excluido = PilhaArray[TopoN++];							// Remoção e armazenamento do elemento preto removido
		return excluido;											// Retorno do elemento preto removido	
	}
	
	public T TopVermelho()
	{
		IsEmptyVermelho();											// Verifica se o lado vermelho da PilhaArray está vazio
		return PilhaArray[TopoR]; 									// Retorno do elemento do topo vermelho
	}
	
	public T TopPreto()
	{
		IsEmptyPreto();												// Verifica se o lado preto da PilhaArray está vazio
		return PilhaArray[TopoN]; 									// Retorno do elemento do topo preto
	}
	
	public void IsEmptyVermelho()
	{
		if(TopoR == -1) throw new PilhaVaziaExcecao("Não há Elementos Vermelhos na Pilha");			// Verifica se o lado vermelho da PilhaArray está vazio (TopoVermelho = -1 -> Vazio)
	}
	
	public void IsEmptyPreto()
	{
		if(TopoN == Capacidade) throw new PilhaVaziaExcecao("Não há Elementos Pretos na Pilha");	// Verifica se o lado preto da PilhaArray está vazio (TopoPreto = Capacidade -> Vazio)
	}
	
	public int Size()
	{
		return (TopoR + 1) + (Capacidade - TopoN);					// Retorno da quantidade de elementos da PilhaArray Rubro-Negra
	}

	public void ExibirPilhaRubroNegra()
	{
		Console.WriteLine("Pilha Rubro-Negra");

		for (int i = 0; i < PilhaArray.Length; i++)					// Exibir todos os elementos da PilhaArray Rubro-Negra
		{
			if (i <= TopoR)											// Exibir elementos vermelhos da PilhaArray
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.BackgroundColor = ConsoleColor.Gray;
				Console.Write($"| {PilhaArray[i]} |");
				Console.ResetColor();
			}
			else if (i >= TopoN)									// Exibir elementos pretos da PilhaArray
			{
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.Gray;
				Console.Write($"| {PilhaArray[i]} |");
				Console.ResetColor();
			}
			else													// Exibir espaços vazios da PilhaArray
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Gray;
				Console.Write("| * |");
				Console.ResetColor();
			}
		}

		Console.WriteLine("\n");
	}
}