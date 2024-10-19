# Fiap.Web.SmartWasteManagement
## A Aplicação é um CRUD de Coleta Inteligente e serve para monitorar o gerenciamento de coleta.
É possível realizar operações de crud para gravar dados das coletas de lixo, armazenando tudo em um banco de dados MySQL da nuvem pelos servidores flexiveis Azure.

## Para executar basta acessar o link:
https://fiap-smart-waste-dev-egcdcuczbbbne7hc.eastus2-01.azurewebsites.net/

Se encontra também no repositório do github:
https://github.com/GuiTsuke/Fiap.Web.SmartWasteManagement

Foi usado o Container Docker, hospedado no dockerhub e implementado como um Azure Web Aplication, e Workflows do Github Action para configurar Continuous integration e Continuous Delivery.

Em relação ao projeto, na raiz do repositório há uma solution principal, a pasta de workflows e duas pastas contendo os projetos de teste e principal. Basta abrir a solution da raiz do repositório buildar e rodar publicando localmente ou em um container.

# Resumo do Processo de Integração e Implantação Contínua
O processo de Integração Contínua (CI) e Implantação Contínua (CD) automatiza a construção, testes e implantação de aplicações, permitindo entregas rápidas e confiáveis. Utilizando GitHub Actions, sempre que um commit é feito, um workflow é acionado para construir a aplicação .NET Core, executar testes e criar uma imagem Docker. O Docker encapsula todas as dependências da aplicação, garantindo consistência em diferentes ambientes.
Após a construção da imagem, Azure DevOps gerencia o processo de CD, enviando a imagem Docker para um registro de contêiner, como o Docker Hub. A implantação ocorre em serviços como Azure App Service, com possibilidade de aprovações manuais antes da promoção a produção. A automação da CI/CD reduz o tempo de entrega, aumenta a qualidade do código e assegura consistência e escalabilidade nas implantações.
Esse fluxo de trabalho ágil não só melhora a produtividade da equipe de desenvolvimento, mas também garante a entrega contínua de software de alta qualidade, tornando a integração de novas funcionalidades e correções de bugs mais eficiente.
