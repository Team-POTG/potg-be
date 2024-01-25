import { INestApplication } from "@nestjs/common";
import { DocumentBuilder, SwaggerModule } from "@nestjs/swagger";
import { SummonerModule } from "src/potg/riot/lol/api/summoner/summoner.module";
import { DocumentType } from "../types/document";

export class Document {
  private _app: INestApplication<any>;

  constructor(app: INestApplication<any>) {
    this._app = app;
  }

  public createDocument(document: DocumentType) {
    const _config = new DocumentBuilder()
      .setTitle(document.builder.title ?? "")
      .setDescription(document.builder.description ?? "")
      .setVersion(document.builder.version ?? "")
      .build();
    const _document = SwaggerModule.createDocument(this._app, _config, {
      include: document.module,
    });
    SwaggerModule.setup(document.path, this._app, _document, {
      swaggerOptions: { tryItOutEnabled: true },
    });
  }
}
