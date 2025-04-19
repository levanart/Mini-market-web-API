
# 🛒 Mini-market Web API

**Mini-market Web API** — это простой, но функциональный REST API-проект, созданный на ASP.NET Core. Он эмулирует базовую логику интернет-магазина и работает полностью в памяти без использования баз данных и сторонних ORM. Проект отлично подойдёт для обучения, тестирования HTTP-клиентов или демонстрации принципов построения Web API.

## 📚 Описание

Проект реализует API для управления:

- 📦 **Товарами** (`Products`)
- 🗂 **Категориями товаров** (`Categories`)
- 👤 **Пользователями** (`Users`)

Все данные хранятся в обычных `List<T>`, инициализируемых при запуске приложения. Это означает, что все изменения теряются после перезапуска — поведение идеально подходит для мокапов или начального прототипирования.

## 🧰 Используемые технологии

- .NET 8
- ASP.NET Core Web API
- Swagger (через `Swashbuckle.AspNetCore`)
- In-Memory хранилище (без EF и БД)

## 🚀 Быстрый старт

1. Клонируй проект

   ```bash
   git clone https://github.com/levanart/Mini-market-web-API.git
   cd Mini-market-web-API
   ```

2. Запусти приложение

   ```bash
   dotnet run
   ```

3. Перейди в Swagger для тестирования:

   ```
   https://localhost:5001/swagger
   ```

## 🔧 Структура проекта

```
Mini-market-web-API/
├── Controllers/         # Web API контроллеры
│   ├── ProductController.cs
│   ├── CategoryController.cs
│   └── UserController.cs
│
├── Models/              # Модели для сущностей
│   ├── Product.cs
│   ├── Category.cs
│   └── User.cs
│
├── Program.cs           # Точка входа
├── appsettings.json     # Конфигурация
└── Properties/
    └── launchSettings.json
```

## 📡 Эндпоинты

### 📦 Продукты

- `GET /api/products` — список всех товаров
- `GET /api/products/{id}` — товар по ID
- `POST /api/products` — добавить новый
- `PUT /api/products/{id}` — обновить по ID
- `DELETE /api/products/{id}` — удалить по ID

### 🗂 Категории

Аналогично продуктам — `api/categories`

### 👤 Пользователи

Аналогично — `api/users`

## 🧪 Пример запроса

```http
POST /api/products
Content-Type: application/json

{
  "id": 1,
  "name": "Чай черный",
  "description": "Классический цейлонский чай",
  "price": 149.99,
  "categoryId": 1
}
```

## 🌀 Потенциальное применение

- Прототип API перед интеграцией с базой данных
- Лёгкий стенд для фронтенда или мобильных приложений
- Учебный проект по основам ASP.NET Core
- Подготовка к работе с Swagger, REST и HTTP-клиентами

## 🔮 Возможности для расширения

- Подключение реальной базы данных (например, SQLite или PostgreSQL)
- Внедрение Entity Framework Core
- Аутентификация через JWT
- Валидация моделей с помощью FluentValidation
- Docker-контейнеризация (базовая поддержка уже есть)

## 📄 Лицензия

Проект распространяется под лицензией MIT — см. [LICENSE](LICENSE)
