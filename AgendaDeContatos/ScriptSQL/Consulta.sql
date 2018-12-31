declare @Hoje datetime = getdate() 

 select distinct p.id as 'ID', p.nome as 'Nome', p.email as 'E-mail',
 p.cpf as 'CPF', CONCAT(FLOOR(DATEDIFF(DAY, p.dataNascimento, @Hoje) / 365.25), ' Anos') AS	'Idade',
 count(t.numero) as 'Quantidade de Telefones' from Pessoa p
join Telefone t on t.idPessoa = p.id
group by p.id, p.nome, p.cpf, p.email, p.dataNascimento