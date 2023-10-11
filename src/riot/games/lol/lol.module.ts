import { Module } from '@nestjs/common';
import { LOLService } from './lol.service';
import { LOLController } from './lol.controller';

@Module({
  controllers: [LOLController],
  providers: [LOLService],
})
export class LOLModule {
  constructor(private lolService: LOLService) {}
}
