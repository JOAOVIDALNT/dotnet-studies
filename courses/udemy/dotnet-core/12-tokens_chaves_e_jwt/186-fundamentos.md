A estrutura de um `token JWT` é composta por 3 partes, separadas por pontos:  
`HEADER.PAYLOAD.SIGNATURE`
```json
TOKEN: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c

HEADER: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9
PAYLOAD: eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ
SIGNATURE: SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
```

### Estrutura do Token

Todas as partes do token são `JSONs` serializados em Base64.

#### HEADER

O `header` define o algoritmo de criptografia e o tipo do token:
```json
{
  "alg": "HS256",
  "typ": "JWT"
}
```

#### PAYLOAD

O `payload` contém os dados do token e as `claims`. Lembre-se de que essas informações são visíveis para qualquer um que possua o token, portanto **não** insira dados sensíveis no `payload`.

```json
{
  "sub": "1234567890",
  "name": "John Doe",
  "iat": 1516239022
}
```
> ⚠️ Dica: Embora seja possível criptografar o conteúdo do `payload`, isso não é nativo do JWT e requer um esforço adicional para descriptografia do lado do cliente.

#### SIGNATURE
A assinatura garante a integridade e autenticidade do token. Ela é gerada combinando o `header`, o `payload` e uma `secret` (chave privada da aplicação) usando o algoritmo definido no `header`.

```json
HMACSHA256(
  base64UrlEncode(header) + "." + 
  base64UrlEncode(payload),
  your-256-bit-secret
)
```
A assinatura impede que qualquer parte do token seja alterada sem que o token seja invalidado, já que qualquer mudança nos dados geraria uma assinatura diferente.

### Detalhes Técnicos

- **Base64UrlEncode:** o Base64 padrão gera caracteres especiais como `+` e `/`, que são substituídos por `-` e `_`, respectivamente, na codificação Base64 URL.
- **HMACSHA256:** essa função de criptografia recebe dois parâmetros:
    1. A concatenação do `header` e `payload`, ambos codificados em Base64 URL.
    2. A `secret`, que é uma chave privada da aplicação.

#### Algoritmo de Criptografia

O algoritmo `HMACSHA` é um método de criptografia do tipo `hash`, o que significa que ele **só pode criptografar** os dados e **não pode ser revertido** para obter o conteúdo original. A função combina os valores do `header`, `payload` e `secret` para gerar a assinatura, validando o token. Assim, qualquer alteração no `payload` invalidaria a assinatura, protegendo a integridade dos dados.

#### SECRET

A `secret` da aplicação é **extremamente confidencial**. Se ela for comprometida, será possível criar ou manipular tokens JWT de maneira fraudulenta, o que pode resultar em sérios problemas de segurança.