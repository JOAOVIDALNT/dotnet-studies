Alguns arquivos, como os de `migrations` não vamos conseguir cobrir com testes, por isso, em `coverage` podemos acessar um path, copiar e garantir que ele não vai ser coberto, adicionando a configuração a seguir:

![[Pasted image 20240823211326.png]]

![[Pasted image 20240823212057.png]]

No fim, algumas coberturas não foram possíveis e nem tratamos como exceção, como por exemplo:
- Nenhum teste de unidade cobre o `ThrowUnknowExcpetion`, que por si só já é uma contradição, afinal, pra testar uma exceção, precisamos conhece-la. Existem desenvolvedores que alteram configurações da injeção de dependência pra ter casos de exceção desconhecida mas nós não faremos.