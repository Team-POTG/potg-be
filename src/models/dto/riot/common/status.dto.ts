import { MaxLength, IsString, IsNumber, Length } from "class-validator";

class Status {
  @IsNumber()
  status_code: number;

  @IsString()
  message: string;
}

export class StatusDto {
  @IsNumber()
  status: Status;
}
