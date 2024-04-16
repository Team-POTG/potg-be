# POTG Back-end

> 위 프로젝트를 실행하기 위해서는 [potg-fe](https://github.com/Team-POTG/potg-fe)와 함께 실행하여야 합니다.

### 1. 실행

```
1. MongoDB 설치
2. NodeJS 설치
3. .env 파일 작성
4. npm install
5. npm run start
```

### 1-1. env 작성

1. [Riot Developer Portal](https://developer.riotgames.com)에서 `Riot API Key`(ex. RGAPI-b2022fcf-4d18-4215-bb3e-cfc5ce8c2bf2)를 발급 받습니다.
2. 밑 `{Riot-API-Key}` 부분에 발급받은 Riot API Key를 입력합니다.

```
RIOT_API_KEY={Riot-API-Key}
DATABASE_URI=mongodb://localhost:27017/potg
```

### 2. Swagger

프로젝트 실행에 성공하게 되면 `http://localhost:3001/potg-api`에서 API 테스트를 진행할 수 있습니다.

### 3. 주요 기술스택

```
- Typescript
- Axios
- MongoDB (mongoose)
- NestJS
- Swagger UI
```
