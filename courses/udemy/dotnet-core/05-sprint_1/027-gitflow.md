## Iniciando um git flow:
![[Pasted image 20240609154132.png]]
	Nesse caso todas as configurações já tinham o valor esperado

## Nova branch feature
Aqui está um exemplo de como iniciar uma nova branch de feature:
![[Pasted image 20240609154335.png]]


Com isso, ao aplicar as alterações, adicionar e commitar. O devops deve ficar assim:![[Pasted image 20240609161504.png]]
Com as branches de feature organizadas.

### Finish branch
![[Pasted image 20240609161724.png]]
Ao executar o comando 'git flow feature finish' o gitflow automaticamente realiza o merge da branch feature com a branch develop, commita e apaga a branch feature.

![[Pasted image 20240609163102.png]]


### Detalhes interessantes sobre a interface do git no vs

#### Stash Changes
![[Pasted image 20240609160305.png]]

Retorna o conteúdo da branch para o código atual não alterado. Após isso já é possível incluir essas alterações novamente na mesma branch ou em alguma nova através do Apply:
![[Pasted image 20240609160557.png]]


Importante lembrar de deletar os stashs depois, para não se confundir
![[Pasted image 20240609160645.png]]

- git add:
![[Pasted image 20240609161050.png]]

 - git commit:
 
![[Pasted image 20240609161157.png]]

- git push

![[Pasted image 20240609161247.png]]