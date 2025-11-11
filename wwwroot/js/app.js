const { createApp } = Vue;

createApp({
    data() {
        return {
            apiBaseUrl: window.location.origin,
            selectedGenre: '',
            quantity: 4,
            movies: [],
            loading: false,
            error: '',
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
            ]
        };
    },
    methods: {
        async getRecommendations() {
            this.loading = true;
            this.error = '';
            this.movies = [];

            try {
                const url = `${this.apiBaseUrl}/api/recommendation/random?genre=${this.selectedGenre}&quantity=${this.quantity}`;
                const response = await fetch(url);

                if (!response.ok) {
                    throw new Error(`Erro ${response.status}: ${response.statusText}`);
                }

                this.movies = await response.json();
            } catch (err) {
                this.error = `Falha ao carregar recomendações: ${err.message}`;
                console.error('Error:', err);
            } finally {
                this.loading = false;
            }
        },

        truncateText(text, maxLength) {
            if (text.length <= maxLength) return text;
            return text.substr(0, maxLength) + '...';
        }
    },

    mounted() {
        // Carrega algumas recomendações automaticamente ao iniciar
        this.getRecommendations();
    }
}).mount('#app');