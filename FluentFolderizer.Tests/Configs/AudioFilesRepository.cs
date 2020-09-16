using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFolderizer.Tests.Configs
{
    class AudioFilesRepository
    {
        public AudioFile[] Files =
        {
            new AudioFile {
                Name = "Ariely Bonatti - Alegria Vem Aí",
                Album = aPorta,
                AlbumArtist = arielyBonatti,
                Genre = christian,
                Year = "2014"
            },
            new AudioFile {
                Name = "Ariely Bonatti - Forte Eu Sou",
                Album = aPorta,
                AlbumArtist = arielyBonatti,
                Genre = christian,
                Year = "2014"
            },
            new AudioFile {
                Name = "Asaph Borba - Filho Meu",
                Album = deUmPaiParaSeusFilhos,
                AlbumArtist = asaphBorba,
                Genre = religiosa,
                Year = "2016"
            },
            new AudioFile {
                Name = "Asaph Borba - Melhor Presente",
                Album = deUmPaiParaSeusFilhos,
                AlbumArtist = asaphBorba,
                Genre = religiosa,
                Year = "2016"
            },
            new AudioFile {
                Name = "Asaph Borba - Alegria de Ser Pai",
                Album = deUmPaiParaSeusFilhos,
                AlbumArtist = asaphBorba,
                Genre = religiosa,
                Year = "2016"
            },
            new AudioFile {
                Name = "Asaph Borba - Porta Aberta",
                Album = deUmPaiParaSeusFilhos,
                AlbumArtist = asaphBorba,
                Genre = religiosa,
                Year = "2016"
            },
            new AudioFile {
                Name = "Grupo Logos - Expressão de Louvor (Ao Vivo)",
                Album = tributoVol1,
                AlbumArtist = grupoLogos,
                Genre = religiosa,
                Year = "2002"
            },
            new AudioFile {
                Name = "Grupo Logos - Caminhos (Ao Vivo)",
                Album = tributoVol1,
                AlbumArtist = grupoLogos,
                Genre = religiosa,
                Year = "2002"
            },
            new AudioFile {
                Name = "Grupo Logos - Ponto de Partida (Ao Vivo)",
                Album = tributoVol1,
                AlbumArtist = grupoLogos,
                Genre = religiosa,
                Year = "2002"
            },
            new AudioFile {
                Name = "Grupo Logos - A Paz (Ao Vivo)",
                Album = tributoVol1,
                AlbumArtist = grupoLogos,
                Genre = religiosa,
                Year = "2002"
            },
            new AudioFile {
                Name = "Grupo Logos - Portas Abertas (Ao Vivo)",
                Album = tributoVol1,
                AlbumArtist = grupoLogos,
                Genre = religiosa,
                Year = "2002"
            },
            new AudioFile {
                Name = "",
                Album = autorDaMinhaFe,
                AlbumArtist = grupoLogos,
                Genre = religiosa,
                Year = "1993"
            },
            new AudioFile {
                Name = "Grupo Logos - Cortando o Céu",
                Album = autorDaMinhaFe,
                AlbumArtist = grupoLogos,
                Genre = religiosa,
                Year = "1993"
            },
            new AudioFile {
                Name = "Grupo Logos - Perfeita Paz",
                Album = autorDaMinhaFe,
                AlbumArtist = grupoLogos,
                Genre = religiosa,
                Year = "1993"
            },
            new AudioFile {
                Name = "Grupo Logos - Semente e Fruto",
                Album = autorDaMinhaFe,
                AlbumArtist = grupoLogos,
                Genre = religiosa,
                Year = "1993"
            },
            new AudioFile {
                Name = "Grupo Logos - Mudança",
                Album = autorDaMinhaFe,
                AlbumArtist = grupoLogos,
                Genre = religiosa,
                Year = "1993"
            },
        };

        #region Albums
        private static string aPorta = "A Porta";
        private static string deUmPaiParaSeusFilhos = "De um Pai para Seus Filhos";
        private static string tributoVol1 = "Tributo, Vol. 1 (Ao Vivo)";
        private static string autorDaMinhaFe = "Autor da Minha Fé";
        #endregion

        #region Artists
        private static string arielyBonatti = "Ariely Bonatti";
        private static string asaphBorba = "Asaph Borba";
        private static string grupoLogos = "Grupo Logos";
        #endregion

        #region Genres
        private static string religiosa = "Religiosa";
        private static string christian = "Christian/Gospel";
        #endregion

    }

    class AudioFile
    {
        public string Name { get; set; }
        public string Album { get; set; }
        public string AlbumArtist { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Format { get; set; } = ".mp3";
    }
}
