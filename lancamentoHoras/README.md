# Desafio Back-end Luby Software
**Observações**
- O banco de dados utilizado foi o MySql
- O arquivo com a criação das tabelas do banco de dados está localizado em 'Database_info/database_config.sql'
- Assim que executado, para acessar a documentação swagger-ui basta adicionar "/swagger" ao link. Opcionalmente para a documentação em JSON acesse "/swagger/v1/swagger.json"
- A API que retorna o ranking dos 5 desenvolvedores da semana com maior média de horas trabalhadas está no caminho "/lancamentos/ranking", assim como no documento swagger indica, em caso de dúvida.
- A publicação foi feita para a pasta "lancamentoHoras/bin/Release/netcoreapp3.1/publish" com a configuração de framework-dependent e portable. Lembro também que na publicação a porta utilizada é a 5000(http) enquanto na de desenvolvimento é a 44356(https).
- A maioria das requests necessitam de um token para serem acessadas. Para conseguir o token basta fazer uma requisição POST para "/api/token" com um usuário qualquer no body da request entre aspas(ex.: "tiago"). Em seguida o token deve ser inserido no headers com a key "Authorization" e o valor "Bearer " + [seuToken].
- Qualquer dúvida fiquem à vontade para perguntar que estarei à disposição.
------------
***Tiago Grossi Hasuda***
*tiago.ghasuda@gmail.com*