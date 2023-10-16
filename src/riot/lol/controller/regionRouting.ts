import { log } from "console";
import { RegionOfContinent, RegionOfCountry } from "../types/regions";

export function getCountryToContinent(region: RegionOfCountry) {
  switch (region) {
    case "BR1":
    case "LA1":
    case "LA2":
    case "NA1":
      return "AMERICAS";

    case "EUN1":
    case "EUW1":
    case "TR1":
      return "EUROPE";

    case "JP1":
    case "RU":
    case "KR":
    case "TW2":
      return "ASIA";

    case "OC1":
    case "PH2":
    case "SG2":
    case "TH2":
    case "VN2":
      return "SEA";
  }
}

// export class RegionRoutingController {
//   constructor(region: RegionOfContinent | RegionOfCountry) {
//     region = this.region;
//   }
//   private region: RegionOfContinent | RegionOfCountry;

//   // getContinentToCountry() {
//   //   if (RegionOfContinent.includes(this.region)) {
//   //     switch (this.region) {
//   //       case "AMERICAS":
//   //         break;
//   //       case "ASIA":
//   //         break;
//   //       case "EUROPE":
//   //         break;
//   //       case "SEA":
//   //         break;
//   //     }
//   //   } else {
//   //     return this.region;
//   //   }
//   // }

//   getCountryToContinent() {
//     // if (RegionOfCountry.includes(this.region)) {
//     log(this.region);
//     switch (this.region) {
//       case "BR1":
//       case "LA1":
//       case "LA2":
//       case "NA1":
//         return "AMERICAS";

//       case "EUN1":
//       case "EUW1":
//       case "TR1":
//         return "EUROPE";

//       case "JP1":
//       case "RU":
//       case "KR":
//       case "TW2":
//         return "ASIA";

//       case "OC1":
//       case "PH2":
//       case "SG2":
//       case "TH2":
//       case "VN2":
//         return "SEA";
//     }
//   }
// }
// // }
