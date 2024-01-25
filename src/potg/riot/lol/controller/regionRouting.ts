import { RegionOfCountry } from "../../common/types/regions";

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
