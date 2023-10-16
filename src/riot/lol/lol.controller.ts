import { Controller } from "@nestjs/common";
import { LOLService } from "./lol.service";

@Controller()
export class LOLController {
  constructor(private lolService: LOLService) {}
}
