##### Estrutura de um pipeline mais complexo
![[Pasted image 20240819072111.png]]


### STEPS
Instruções, ao executar o `pipeline` ele deve seguir essas instruções, que podem:
- Copiar um arquivo
- Executar um `build`
- Executar os testes
Se uma instrução falhar, as próximas não serão executadas, ou seja, são executados em sequência, um atrás do outro.

### JOBS
Todo `step` deve estar associado à um `job`, no exemplo que definimos apenas `steps` eles são associados automaticamente à um `job`. `Jobs` são um grupo de instruções (`steps`).
- É no `job` que decidimos que sistema operacional utilizaremos.
- No mesmo arquivo YAML, podemos definir vários `jobs`.
- Podemos ter vários `jobs` em um mesmo arquivo YAML, sendo executados em sistemas operacionais diferentes, com versões diferentes.
 ![[Pasted image 20240819072247.png]]

##### Condicionais
- Podemos atribuir condições aos `jobs`, por exemplo, que um `job` só será executado após o término de um outro, além de outras condições como só deve executar se o `job` que ele depende tiver sucesso ou fracasso. 
![[Pasted image 20240819072412.png]]
![[Pasted image 20240819072609.png]]
##### Execução
- `jobs` são executados em paralelo mas na nossa conta gratuita executaremos um por vez.


###### Visão do Pipeline no Azure

![[Pasted image 20240819072657.png]]


### STAGES
`Stages` são grupos de `jobs`
![[Pasted image 20240819072913.png]]
- No exemplo o `stage` "D" só seria executado se o `stage` "B" falhar.
- Temos todos esses recursos para controle de fluxo, onde uma fase "A" pode publicar em ambientes de teste enquanto outra executa para o ambiente de produção.
- Pipelines podem exigir aprovações.