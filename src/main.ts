import { NestFactory } from "@nestjs/core";
import { AppModule } from "./app.module";
import { DocumentBuilder, SwaggerModule } from "@nestjs/swagger";
import { INestApplication, Ip } from "@nestjs/common";
import { MatchModule } from "./potg/riot/lol/api/match/match.module";
import { Document } from "./document/api/document";
// import { SummonerModule } from "./potg/riot/lol/api/summoner/summoner.module";

async function bootstrap() {
  const app = await NestFactory.create(AppModule);
  app.enableVersioning();
  app.enableCors({
    origin: ["http://localhost:3000"],
  });

  // const document = new Document(app);

  // setPOTGDocument(document);
  // setProviderDocument(document);
  // setRequestDocument(document);

  const config = new DocumentBuilder()
    .setTitle("POTG")
    .setDescription("POTG RestAPI Document")
    .setVersion("BETA1")
    .build();
  app.enableVersioning();
  const document = SwaggerModule.createDocument(app, config);
  SwaggerModule.setup("potg-api", app, document, {
    swaggerOptions: { tryItOutEnabled: true },
  });

  // document.createDocument({
  //   path: "api/provider/riot/lol",
  //   module: [LOLModule],
  //   builder: {
  //     title: "Riot LOL API",
  //     description: "Riot LOL API",
  //     version: "",
  //   },
  // });

  // document.createDocument("api/provider/riot/lol/account", [AccountModule], {
  //   title: "Riot Account API",
  //   description: "Riot Account API",
  //   version: "VERSION 4",
  // });
  // document.createDocument("api/potg/riot/lol/account", [AccountModule]);

  await app.listen(3001);
}
bootstrap();
