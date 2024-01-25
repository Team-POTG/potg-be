import { Prop, Schema, SchemaFactory } from "@nestjs/mongoose";
import { ApiProperty } from "@nestjs/swagger";
import { HydratedDocument } from "mongoose";

export type StatusDocument = HydratedDocument<Status>;

class StatusInfo {
  @Prop()
  @ApiProperty()
  status_code: number;

  @Prop()
  @ApiProperty()
  message: string;
}

@Schema()
export class Status {
  @Prop()
  @ApiProperty()
  status: StatusInfo;
}

export const StatusSchema = SchemaFactory.createForClass(Status);
