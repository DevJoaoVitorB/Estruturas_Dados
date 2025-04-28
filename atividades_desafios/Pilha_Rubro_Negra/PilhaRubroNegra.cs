using System;

public class PilhaRubroNegra<T> : Pilha<T>
{
	private int topoR;						// Atributo do topo vermelho da pilha			
	private int topoN;						// Atributo do topo preto da pilha
	private int capacidade;					// Atributo da capacidade da pilha
	private int FC;							// Atributo do fator de crescimento da pilha
	private T[] pilhaArray;					// PilhaArray
	
	public PilhaRubroNegra(int capacidade, int crescimento)
	{
		this.capacidade = capacidade;		// Definindo a capacidade da PilhaArray
		
		if(crescimento<=0) FC = 0;			// Redirecionamento de capacidade Duplicativo
		else FC = crescimento;				// Redirecionamento de capacidade Incremental
		
		pilhaArray = new T[capacidade];		// Criação da PilhaArray
		
		topoR = -1;							// Definição do topo vermelho
		topoN = capacidade;					// Definição do topo preto
	}
	
	public void aumentarCapacidade()
	{
		if(topoR==topoN - 1)										// Verificação da capacidade da PilhaArray (TRUE = Cheia, FALSE = Livre)
		{
			int indiceCapacidadeAntiga = capacidade - 1;			// Variavel auxiliar do índice máximo da capacidade antiga
			
			if(FC==0) capacidade *= 2;								// Estratégia Duplicativa
			else capacidade += FC;									// Estratégia Incremental
			
			int indiceCapacidadeNova = capacidade - 1;				// Variavel auxiliar do índice máximo da capacidade nova
	
			T[] arrayTemp = new T[capacidade];						// Criação da PilhaArray auxiliar temporária
			
			for(int i = 0; i <= topoR; i++)					
			{
				arrayTemp[i] = pilhaArray[i];						// Transferindo elementos vermelhos para a PilhaArray auxiliar
			}
			
			for(int j = indiceCapacidadeAntiga; j >= topoN; j--)
			{
				arrayTemp[indiceCapacidadeNova] = pilhaArray[j];	// Transferindo elementos pretos para a PilhaArray auxiliar
				indiceCapacidadeNova--;
			}

			topoN = indiceCapacidadeNova + 1;						// Novo topo preto para a PilhaArray
			
			pilhaArray = arrayTemp;									// PilhaArray temporária passa a ser a PilhaArray principal
		}
	}
	
	public void pushVermelho(T objeto)
	{	
		aumentarCapacidade();										// Verifica a capacidade antes do push do elemento vermelho
		pilhaArray[++topoR] = objeto;								// Adiciona o elemento vermelho na PilhaArray
	}
	
	public void pushPreto(T objeto)
	{
		aumentarCapacidade();										// Verifica a capacidade antes do push do elemento preto
		pilhaArray[--topoN] = objeto;								// Adiciona o elemento preto na PilhaArray
	}

	public void reduzirCapacidade()
    {
        if(size() <= capacidade/3)									// Verificação da capacidade da PilhaArray (TRUE = Abaixo da Capacidade Esperada, FALSE = Capacidade Esperada)
        {
            int indiceCapacidadeAntiga = capacidade - 1;			// Variavel auxiliar do índice máximo da capacidade antiga

            capacidade /= 2;										// Redução da capacidade da PilhaArray pela metade

            int indiceCapacidadeNova = capacidade - 1;				// Variavel auxiliar do índice máximo da capacidade nova

			T[] arrayTemp = new T[capacidade];						// Criação da PilhaArray auxiliar temporária
			
			for(int i = 0; i <= topoR; i++)
			{
				arrayTemp[i] = pilhaArray[i];						// Transferindo elementos vermelhos para a PilhaArray auxiliar
			}
			
			for(int j = indiceCapacidadeAntiga; j >= topoN; j--)
			{
				arrayTemp[indiceCapacidadeNova] = pilhaArray[j];	// Transferindo elementos pretos para a PilhaArray auxiliar
				indiceCapacidadeNova--;
			}

			topoN = indiceCapacidadeNova + 1;						// Novo topo preto para a PilhaArray
			
			pilhaArray = arrayTemp;									// PilhaArray temporária passa a ser a PilhaArray principal
        }
    }
	
	public T popVermelho()
	{
		isEmptyVermelho();											// Verifica se o lado vermelho da PilhaArray está vazio
        reduzirCapacidade();										// Verifica a capacidade antes do pop do elemento vermelho
		T removido = pilhaArray[topoR--];							// Remoção e armazenamento do elemento vermelho removido
		return removido;											// Retorno do elemento vermelho removido
	}
	
	public T popPreto()
	{
		isEmptyPreto();												// Verifica se o lado preto da PilhaArray está vazio
        reduzirCapacidade();										// Verifica a capacidade antes do pop do elemento preto
		T excluido = pilhaArray[topoN++];							// Remoção e armazenamento do elemento preto removido
		return excluido;											// Retorno do elemento preto removido	
	}
	
	public T topVermelho()
	{
		isEmptyVermelho();											// Verifica se o lado vermelho da PilhaArray está vazio
		return pilhaArray[topoR]; 									// Retorno do elemento do topo vermelho
	}
	
	public T topPreto()
	{
		isEmptyPreto();												// Verifica se o lado preto da PilhaArray está vazio
		return pilhaArray[topoN]; 									// Retorno do elemento do topo preto
	}
	
	public void isEmptyVermelho()
	{
		if(topoR == -1) throw new PilhaVaziaExcecao("Não há Elementos Vermelhos na Pilha");	// Verifica se o lado vermelho da PilhaArray está vazio (TopoVermelho = -1 -> Vazio)
	}
	
	public void isEmptyPreto()
	{
		if(topoN == capacidade) throw new PilhaVaziaExcecao("Não há Elementos Pretos na Pilha");	// Verifica se o lado preto da PilhaArray está vazio (TopoPreto = Capacidade -> Vazio)
	}
	
	public int size()
	{
		return (topoR + 1) + (capacidade - topoN);					// Retorno da quantidade de elementos da PilhaArray Rubro-Negra
	}

	public void exibirPilhaRubroNegra()
	{
		Console.WriteLine("Pilha Rubro-Negra");

		for (int i = 0; i < pilhaArray.Length; i++)					// Exibir todos os elementos da PilhaArray Rubro-Negra
		{
			if (i <= topoR)											// Exibir elementos vermelhos da PilhaArray
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.BackgroundColor = ConsoleColor.Gray;
				Console.Write($"| {pilhaArray[i]} |");
				Console.ResetColor();
			}
			else if (i >= topoN)									// Exibir elementos pretos da PilhaArray
			{
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.Gray;
				Console.Write($"| {pilhaArray[i]} |");
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