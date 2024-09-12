# LetsGoCamping

## Project Overview

**LetsGoCamping** is a web application that allows users to log in, create multiple trips, send invitations to friends, and track responses. The application features information such as trip locations, planned hikes, activities, and a calendar with the duration marked. Built with React for the frontend and .NET (C#) for the backend, this project utilizes Vite for fast builds and Tailwind CSS for styling.

## Features

- User authentication and authorization
- Create and manage multiple trips
- Send and manage trip invitations
- Track responses (Yes, Maybe, No)
- View trip details, including location, planned hikes, and activities
- Calendar view with trip duration

## Technologies

- **Frontend**: React, Vite, Tailwind CSS
- **Backend**: .NET (C#), ASP.NET Core
- **Database**: [Your choice of free remote database] (e.g., Azure SQL Database, PostgreSQL on Render)
- **ORM**: Entity Framework Core

## Setup

### Prerequisites

- Node.js and npm (or Yarn) installed
- .NET SDK installed
- Git installed

### Frontend Setup

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/LetsGoCamping.git
   cd LetsGoCamping
   ```

2. **Navigate to the Frontend Directory**

   ```bash
   cd frontend
   ```

3. **Install Dependencies**

   ```bash
   npm install
   ```

4. **Run the Development Server**

   ```bash
   npm run dev
   ```

   The application will be available at `http://localhost:5173/`.

### Backend Setup

1. **Navigate to the Backend Directory**

   ```bash
   cd ../backend
   ```

2. **Restore Dependencies**

   ```bash
   dotnet restore
   ```

3. **Apply Migrations**

   ```bash
   dotnet ef database update
   ```

4. **Run the Development Server**

   ```bash
   dotnet run
   ```

   The API will be available at `http://localhost:5000/` (default port).

## Configuration

### Environment Variables

Create a `.env` file in the root directory of the frontend and backend with the following variables:

#### Frontend (`frontend/.env`)

```bash
VITE_API_URL=http://localhost:5000
```

#### Backend (`backend/appsettings.json`)

Configure your database connection string and other settings in the `appsettings.json` file.

## Webhooks

The project includes GitHub webhooks to notify the Discord server of push events. Ensure the webhook is configured correctly:

- **Discord Webhook URL**: [Insert your Discord webhook URL here]
- **GitHub Webhook Events**: Push events

## Deployment

To deploy the project:

1. **Frontend**: Build the project with Vite and deploy the static files to a hosting service like Vercel, Netlify, or GitHub Pages.

   ```bash
   npm run build
   ```

2. **Backend**: Deploy the .NET application to a cloud service like Azure App Service or Heroku.

## Contributing

1. **Fork the Repository** and create a new branch.
2. **Make Changes** and commit your updates.
3. **Push Your Changes** and create a pull request.

Please refer to the [CONTRIBUTING.md](CONTRIBUTING.md) for more details.

## License

This project is licensed under the [MIT License](LICENSE).

## Contact

For any inquiries, please contact:

- **Ibrahim Houissa**
- **GitHub** - https://github.com/ihouissa
