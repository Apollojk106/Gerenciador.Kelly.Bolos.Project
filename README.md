Esse é um projeto criado para uma confeiteira de bolos, qual usa mysql e c# para uma melhor visualização de dados do rendimentos e custos!  

Email:teste@gmail.com
Senha: Teste123

O banco de dados de teste 

create database KellyBolos;

use KellyBolos;

create table Usuario( Email varchar(30), Senha varchar(200), SaltKey varchar(100));

insert into Usuario(Email, Senha, SaltKey) Values ('teste@gmail.com','962253f935de359e718795086ee45cc87086d1ccb51110c360b3877f02ba994b','asdfg6tyansç342');

create table Pedidos(ID int auto_increment primary key, Nome varchar(30), Item varchar(50), Kg float, ValorGasto float, ValorCobrado float, Data date, Endereco varchar(50), Descricao varchar(100) );

INSERT INTO Pedidos (Nome, Item, Kg, ValorGasto, ValorCobrado, Data, Endereco, Descricao)
VALUES
('Ana', 'Bolo Brigadeiro', 1.5, 25.00, 70.00, '2024-06-10', 'Rua das Flores, 123', 'Bolo Brigadeiro tradicional com chocolate belga e granulado.'),
('Silva', 'Bolo Brigadeiro', 2.0, 35.00, 62.00, '2024-06-12', 'Avenida Paulista, 456', 'Bolo Brigadeiro tradicional com chocolate belga e granulado.'),
('Pereira', 'Bolo Brigadeiro', 1.0, 30.00, 81.60, '2024-06-14', 'Praça da Liberdade, 789', 'Bolo Brigadeiro tradicional com chocolate belga e granulado.'),
('Souza', 'Bolo Red Velvet', 1.2, 22.00, 76.40, '2024-06-08', 'Alameda Santos, 1011', 'Bolo Red Velvet com recheio de cream cheese e cobertura de veludo vermelho.'),
('Santos', 'Bolo Red Velvet', 1.5, 27.00, 72.40, '2024-06-11', 'Rua Augusta, 1213', 'Bolo Red Velvet com recheio de cream cheese e cobertura de veludo vermelho.'),
('Oliveira', 'Bolo Red Velvet', 0.8, 41.00, 98.00, '2024-06-09', 'Rua das Flores, 123', 'Bolo Red Velvet com recheio de cream'),
('Carlos', 'Torta de Limão', 1.8, 30.00, 36.00, '2024-06-13', 'Rua das Margaridas, 234', 'Torta caseira de limão com massa crocante e recheio cremoso.'),
('Carlos', 'Brigadeiro Gourmet', 0.5, 12.00, 14.40, '2024-06-13', 'Rua das Margaridas, 234', 'Brigadeiro tradicional com chocolate belga e toque especial de especiarias.');
