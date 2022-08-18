export class FreebiesService {
  idNum: number = 0;
  freebies = [
    {
      id: this.idNum++, name: 'The Elder Scrolls Online', developer: 'ZeniMax Online Studios', publisher: 'Bethesda Softworks', platform: 'ESO Launcher', type: 'FREE from August 16 - 29',
      image: 'https://cdn.cloudflare.steamstatic.com/steam/apps/306130/header.jpg?t=1659369103',
      description: 'Join over 20 million players in the award-winning online multiplayer RPG and experience limitless adventure in a persistent Elder Scrolls world. Battle, craft, steal, or explore, and combine different types of equipment and abilities to create your own style of play. No game subscription required.', link: 'https://www.elderscrollsonline.com/en-us/freeplay'
    },
    {
      id: this.idNum++, name: 'DOOM 64', developer: 'Midway Studios San Diego', publisher: 'Bethesda Softworks', platform: 'EPIC', type: 'FREE until 8/25/2022', image: 'https://cdn1.epicgames.com/offer/0ea70edafcc54b3191e262bbb6971981/EGS_DOOM64_idSoftwareNightdiveStudios_S1_2560x1440-ad0080b34010d3c86254227a14e96494',
      description: 'Play the enhanced version of the original game released on the Nintendo 64 in 1997. Years have passed since you stopped Hell’s invasion of Earth. Quarantined for humanity’s safety, the UAC research facilities on Mars were abandoned and forgotten...until now.', link: 'https://store.epicgames.com/en-US/p/doom-64'
    },
    {
      id: this.idNum++, name: 'Guild Wars 2', developer: 'ArenaNet®', publisher: 'NCSOFT', platform: 'Steam', type: 'FREE on 8/23/2022', image: 'https://cdn.cloudflare.steamstatic.com/steam/apps/1284210/header.jpg?t=1660656626',
      description: 'Guild Wars 2 is an award-winning online roleplaying game with fast-paced action combat, deep character customization, and no subscription fee required. Choose from an arsenal of professions and weapons, explore a vast open world, compete in PVP modes and more. Join over 16 million players now! ', link: 'https://store.steampowered.com/app/1284210/Guild_Wars_2/'
    },
    {
      id: this.idNum++, name: 'The Elder Scrolls: Arena', developer: 'Bethesda Softworks', publisher: 'Bethesda Softworks', platform: 'Steam', type: 'FREE',
      image: 'https://cdn.cloudflare.steamstatic.com/steam/apps/1812290/header.jpg?t=1650992611',
      description: 'The imperial battlemage Jagar Tharn betrays the Emperor Uriel Septim by imprisoning him in an alternate dimension, then assuming the Emperor’s identity and place on the throne. A lone prisoner must travel to Tamriel’s most famous and dangerous sites to collect the shattered Staff of Chaos, save the Emperor and free the Empire.', link: 'https://store.steampowered.com/app/1812290/The_Elder_Scrolls_Arena/'
    },
    {
      id: this.idNum++, name: 'The Elder Scrolls II: Daggerfall', developer: 'Bethesda Softworks, Flashpoint Productions', publisher: 'Bethesda Softworks', platform: 'Steam', type: 'FREE',
      image: 'https://cdn.cloudflare.steamstatic.com/steam/apps/1812390/header.jpg?t=1656353357',
      description: 'The ancient golem Numidium, a powerful weapon once used by the great Tiber Septim to unify Tamriel, has been found in Iliac Bay. In the power struggle that follows, the King of Daggerfall is murdered and his spirit haunts the kingdom. The Emperor Uriel Septim VII sends his champion to the province of High Rock to put the king’s spirit to rest and ensure that the golem does not fall into the wrong hands. ', link: 'https://store.steampowered.com/app/1812390/The_Elder_Scrolls_II_Daggerfall/'
    },
    {
      id: this.idNum++, name: 'Republique', developer: 'Camouflaj', publisher: 'Camouflaj', platform: 'Steam', type: 'FREE',
      image: 'https://cdn.cloudflare.steamstatic.com/steam/apps/317100/header.jpg?t=1659573361',
      description: 'Help a woman named Hope escape in a thrilling and topical stealth-action game that explores the perils of government surveillance in the Internet Age.', link: 'https://store.steampowered.com/app/317100/Republique/'
    },
    {
      id: this.idNum++, name: 'Republique VR', developer: 'Camouflaj, Darkwind Media', publisher: 'Camouflaj', platform: 'Steam', type: 'FREE',
      image: 'https://cdn.cloudflare.steamstatic.com/steam/apps/915200/header.jpg?t=1659573592',
      description: 'Developed over five years by industry veterans (Metal Gear Solid, Halo, F.E.A.R.), RÉPUBLIQUE VR is a thrilling and topical stealth-action game that explores the perils of government surveillance in the Internet Age.', link: 'https://store.steampowered.com/app/915200/Republique_VR/'
    },
    {
      id: this.idNum++, name: 'BATTALION: Legacy', developer: 'BULKHEAD', publisher: 'BULKHEAD', platform: 'Steam', type: 'FREE',
      image: 'https://img.gg.deals/ce/bf/cf26e1ba129275a5720fb2337a14cd231400_1824cr953.jpg',
      description: 'BATTALION: Legacy is an online shooter set during WW2 that focuses on smaller team fights and tries to recreate the classic competitive FPS experience.', link: 'https://store.steampowered.com/app/489940/BATTALION_Legacy/'
    }
  ]
}