import { Prop, Schema, SchemaFactory } from "@nestjs/mongoose";
import { HydratedDocument } from "mongoose";

export type AccountDocument = HydratedDocument<Account>;

@Schema()
export class Account {
  @Prop()
  puuid: string;

  @Prop()
  gameName: string;

  @Prop()
  tagLine: string;
}

export const AccountSchema = SchemaFactory.createForClass(Account);
