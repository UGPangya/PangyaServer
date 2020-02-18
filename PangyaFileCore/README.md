# PangyaFileCore
  
Criado para Leitura dos arquivos .IFF do pangya com GameServer

Minha idéia atual ajudar a comunidade na leitura dos arquivos.

Atualizações 06/09/2019, Suportando Diversos Arquivos Agora.

Criado o Library PangyaFileCore. Com isto, toda estrutura e responsabilidade de ler os arquivos é desta biblioteca.


Agradeço o Usuário eantoniobr que tem ajudado.

Vocês também podem ajudar, meus agradeçimentos serão acrescentados aqui.

-------------------------------------------------------------------------------------------------------------------------------
                                              Como Usar:

é necessario criar uma pasta com nome "data", dentro dela deve colocar o arquivo " pangya_gb.iff "

é necessario também ter o Visual Studio 2017 Instalado na sua Maquina para compilar o projeto

é usavel em GameServer ou outros programas 

mencione a DLL na unit que ira inicia o programa


como program.cs  

using PangyaFileCore.IffManager;

 
//Classe é estatistica, só é necessario carregar uma unica vez

//ira carrega toda a leitura de arquivos .iff direto na dll e pode ser consumido 

IffMain.Load(); 
 
//irá passar o item encontrado para " test " se existir, se não vira como null

//ira procurar em todos os iff carregados e retornar os cados deste iff usando  typeID

var test = IffMain.IFFFileManager.FindAllFiles(1073741857); 

-------------------------------------------------------------------------------------------------------------------------------

