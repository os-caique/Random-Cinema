const { createApp } = Vue;

createApp({
    data() {
        return {
            apiBaseUrl: window.location.origin,
            selectedGenre: '',
            movies: [],
            loading: false,
            error: '',
            selectedMovie: null,
            genres: [
                { id: '28', name: 'Ação' },
                { id: '12', name: 'Aventura' },
                { id: '16', name: 'Animação' },
                { id: '35', name: 'Comédia' },
                { id: '18', name: 'Drama' },
                { id: '27', name: 'Terror' },
                { id: '10749', name: 'Romance' },
                { id: '878', name: 'Ficção Científica' },
                { id: '53', name: 'Thriller' }
            ],
            languages: {
                'en': 'Inglês',
                'es': 'Espanhol',
                'fr': 'Francês',
                'de': 'Alemão',
                'it': 'Italiano',
                'pt': 'Português',
                'ja': 'Japonês',
                'ko': 'Coreano',
                'zh': 'Chinês',
                'ru': 'Russo',
                'hi': 'Hindi',
                'ar': 'Árabe'
            }
        };
    },
    methods: {
        async getRecommendations() {
            this.loading = true;
            this.error = '';
            this.movies = [];

            try {
                const url = `${this.apiBaseUrl}/api/recommendation/random?genre=${this.selectedGenre}`;
                const response = await fetch(url);

                if (!response.ok) {
                    throw new Error(`Erro ${response.status}: ${response.statusText}`);
                }

                const moviesData = await response.json();
                // Adiciona propriedade para controlar a exibição da descrição
                this.movies = moviesData.map(movie => ({
                    ...movie,
                    showFullOverview: false
                }));
            } catch (err) {
                this.error = `Falha ao carregar recomendações: ${err.message}`;
                console.error('Error:', err);
            } finally {
                this.loading = false;
            }
        },

        truncateText(text, maxLength) {
            if (!text) return 'Descrição não disponível.';
            if (text.length <= maxLength) return text;
            return text.substr(0, maxLength) + '...';
        },

        handleImageError(event) {
            // Substitui a imagem quebrada pelo placeholder
            const parent = event.target.parentElement;
            parent.innerHTML = `
                <div class="no-poster">
                    <span>🎬</span>
                    <p>Cartaz Indisponível</p>
                </div>
            `;
        },

        toggleOverview(movie) {
            movie.showFullOverview = !movie.showFullOverview;
        },

        showFullDescription(movie) {
            this.selectedMovie = movie;
        },

        closeModal() {
            this.selectedMovie = null;
        },

        getLanguageName(code) {
            return this.languages[code] || code.toUpperCase();
        }
    },

    mounted() {
        // Carrega algumas recomendações automaticamente ao iniciar
        this.getRecommendations();
    }
}).mount('#app');