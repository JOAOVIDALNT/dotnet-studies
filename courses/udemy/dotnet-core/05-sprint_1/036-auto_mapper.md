
### Configuração da entidade mapeadora

Para realizar o mapeamento, criaremos dentro de Application o seguinte arquivo mapping config:
![[Pasted image 20240718063724.png]]
Observe que utilizaremos os métodos para definir melhor os mapeamentos.
Também trabalharemos individualmente na senha mas nesse caso, ao invés de o parâmetro option de ForMember mapear de src.Password, nós vamos ignorar, para que a criptografia seja realizada e atribuída posteriormente.
- Uma ideia interessante seria consultar a possibilidade de criptografar no mapeamento
	 ex: .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password.Cript()));
	 - o método string Cript(this string senha) realizaria a criptografia. Considerando que a fonte é um request de registro, acho viável.

#### Ignore:
![[Pasted image 20240718064316.png]]

Exemplo de mapeamento sem injeção de dependência:
![[Pasted image 20240718065852.png]]