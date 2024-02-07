import { Module } from "@nestjs/common";
import { SpectatorController } from "./spectator.controller";
import { SpectatorService } from "./spectator.service";

@Module({
  imports: [],
  controllers: [SpectatorController],
  providers: [SpectatorService],
})
export class SpectatorModule {
  constructor(private spectatorService: SpectatorService) {}
}
