import { NestFactory } from "@nestjs/core";
import { AppModule } from "./app.module";
import { DocumentBuilder, SwaggerModule } from "@nestjs/swagger";

declare const module: any;

async function bootstrap() {
  console.log("zz" + process.env.DATABASE_URI);
  const app = await NestFactory.create(AppModule);

  const config = new DocumentBuilder()
    .setTitle("POTG")
    .setDescription("POTG RestAPI Document")
    .setVersion("BETA1")
    .build();
  const document = SwaggerModule.createDocument(app, config);
  SwaggerModule.setup("potg-api", app, document, {
    swaggerOptions: { tryItOutEnabled: true },
  });

  await app.listen(3001);
}
bootstrap();
