import { FilterModel } from './filter.model';
import { SchemeModel } from './scheme.model';
import { MastermindModel } from './mastermind.model';
import { VillainModel } from './villain.model';
import { HenchmanModel } from './henchman.model';

export class VillainDeckModel {
    filter: FilterModel;
    scheme: SchemeModel;
    masterminds: MastermindModel[];
    villains: VillainModel[];
    henchmen: HenchmanModel[];
}