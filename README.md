Esse é um projeto criado para uma confeiteira de bolos, qual usa mysql e c# para uma melhor visualização de dados do rendimentos e custos  

Email:teste@gmail.com
Senha: Teste123

O banco de dados de teste 

create database Bolos;

use Bolos;

create table Usuario(
Email varchar(30),
Senha varchar(200),
SaltKey varchar(100));

insert into Usuario(Email, Senha, SaltKey) Values ('teste@gmail.com','962253f935de359e718795086ee45cc87086d1ccb51110c360b3877f02ba994b','asdfg6tyansç342');

create table Pedido(
	Nome varchar(30),
    Item varchar(50),
    Kg float,
    ValorGasto float,
    ValorCobrado float,
    Data date,
    Endereço varchar(50),
    Descrição varchar(100)
);
