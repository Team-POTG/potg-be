import { Prop, Schema, SchemaFactory } from "@nestjs/mongoose";
import { ApiProperty } from "@nestjs/swagger";
import { HydratedDocument } from "mongoose";

export type AccountDocument = HydratedDocument<Account>;

@Schema()
export class Account {
  @Prop()
  @ApiProperty()
  puuid: string;

  @Prop()
  @ApiProperty()
  gameName?: string;

  @Prop()
  @ApiProperty()
  tagLine?: string;
}

export const AccountSchema = SchemaFactory.createForClass(Account);
