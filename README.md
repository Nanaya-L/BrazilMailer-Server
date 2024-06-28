# Bem-vindo à Brazil Mailer !

Esta API permite enviar emails de forma eficiente através de um microserviço dedicado para integração em suas aplicações.

## Como Usar

Para enviar um email, faça uma requisição HTTP POST para o endpoint `api/Mailer` com os seguintes parâmetros:

### Endpoint

api/mailer

### Parâmetros

- **from**: (String) Nome de quem envia.
- **to**: (String) Endereço de email do destinatário.
- **subject**: (String) Assunto do email.
- **html**: (String) Conteúdo do email, pode ser em texto simples ou HTML.

