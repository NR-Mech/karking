# Karking

✅ Esse foi o projeto da disciplina de Sistema Embarcados, ministrada pelo professor Geovanne Alves, no curso de ADS da Faculdade Nova Roma.

🌐 Integrantes do grupo: Gutto França, Marcondes Oliveira, Wendell Marinho e Zaqueu Cavalcante.

🚗 O projeto é um sistema de estacionamento simplificado:
- Hardware: protoboards, ESP32, leitores RFID, servo motores, buzzers e leds.
- Software: front em React, back em .NET e banco Postgres.
- O ESP32 consegue se conectar facilmente à rede WiFi, então foi simples juntar tudo.

📌 O fluxo principal é o seguinte:
- Antes de entrar no estacionamento, um sensor RFID pega a placa do carro e manda pra API salvar no banco.
- Em seguida a entrada é liberada e para cada minuto de permanência é cobrado R$ 1,00.
- Um token de 4 dígitos é vinculado a cada veículo. Ele simboliza o ticket do estacionamento e é usado para realizar o pagamento no final.
- Ao tentar sair do estacionamento, a placa é lida novamente e um novo request é feito para a API, verificando se o ticket foi pago.
- Caso o ticket esteja pendente ainda, a saída é bloqueada.
- Caso esteja pago, a saída é liberada.
- O pagamento é feito via frontend, bastando informar a placa do carro + token de 4 dígitos.

🚧 Existe também um caso especial que conseguimos tratar:
- Alguém poderia entrar no estacionamento, pagar apenas R$ 1,00 e só sair no final do dia, burlando a política de preço.
- Pensando nisso, após a relização do pagamento existe um tempo de carência de 1 minuto para que o veículo saia do estacionamento.
- Caso ele demore mais que isso, uma nova contagem se inicia e ele terá que pagar novamente pelo tempo adicional para poder sair.
