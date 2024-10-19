# Fiap.Web.SmartWasteManagement
##A Aplicação é um CRUD de Coleta Inteligente e serve para monitorar o gerenciamento de coleta.
É possível realizar operações de crud para gravar dados das coletas de lixo, armazenando tudo em um banco de dados MySQL da nuvem pelos servidores flexiveis Azure.

##Para executar basta acessar o link:
https://fiap-smart-waste-dev-egcdcuczbbbne7hc.eastus2-01.azurewebsites.net/

Se encontra também no repositório do github:
https://github.com/GuiTsuke/Fiap.Web.SmartWasteManagement

Foi usado o Container Docker, hospedado no dockerhub e implementado como um Azure Web Aplication, e Workflows do Github Action para configurar Continuous integration e Continuous Delivery.

Em relação ao projeto, na raiz do repositório há uma solution principal, a pasta de workflows e duas pastas contendo os projetos de teste e principal. Basta abrir a solution da raiz do repositório buildar e rodar publicando localmente ou em um container.
