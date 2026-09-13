# Report Service

Тестовое задание: асинхронная обработка запросов пользовательской статистики на ASP.NET Core Web API
(.NET 10, EF Core, PostgreSQL).

## Запуск

Нужны .NET 10 SDK и Docker.

```bash
docker compose up -d --wait
dotnet run --project src/ReportService.Api
```

Миграции и демо-данные применяются при старте. API — `http://localhost:5007`, Swagger — `/swagger`,
проверка БД — `/health`. PostgreSQL — `127.0.0.1:5433`, база, пользователь и пароль — `report_service`.

Тесты: `dotnet test`, Docker не нужен.

## API

`POST /report/user_statistics` — `202 Accepted`, в теле Guid запроса, в `Location` — адрес статуса:

```json
{"user_id":"b28d0ced-8af5-4c94-8650-c7946241fd1a","date_from":"2026-01-01","date_to":"2026-01-31"}
```

`GET /report/info?query={guid}`:

```json
{"query":"…","percent":50,"result":null}
{"query":"…","percent":100,"result":{"user_id":"b28d0ced-8af5-4c94-8650-c7946241fd1a","count_sign_in":12}}
```

Готовые запросы, включая ошибочные, — в `src/ReportService.Api/ReportService.Api.http`.

## Настройки

| Ключ | По умолчанию | Назначение |
|---|---|---|
| `ReportProcessing:ProcessingDurationMs` | `60000` | время обработки X |
| `ReportProcessing:PollingIntervalMs` | `1000` | период фоновой обработки |

Переопределяются переменными окружения, например `ReportProcessing__ProcessingDurationMs=10000`.

## Демо-данные

| `user_id` | Январь 2026 | Февраль 2026 | Март 2026 |
|---|---|---|---|
| `b28d0ced-8af5-4c94-8650-c7946241fd1a` | 12 | 8 | 5 |
| `4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c` | 3 | 15 | 9 |
| `8e2d4b6a-1c3f-4a5e-9b7d-0f2a4c6e8b1d` | 1 | 2 | 1 |

## Допущения

- Источник входов в ТЗ не указан — `count_sign_in` считается по таблице с демо-данными.
- `count_sign_in` — число: в примере ТЗ он записан строкой, но `percent` там же числом.
- Поля запроса — `user_id`, `date_from`, `date_to`, параметр статуса — `query`; даты — `yyyy-MM-dd` или
  ISO 8601; период включает оба дня, сутки по UTC.
- `percent` округляется вниз (на 44,9 с — 74), `result` появляется ровно на 100 %.
- Отсчёт идёт по часам: пока приложение выключено, время обработки не останавливается.
- Неизвестный `query` — `404`, невалидный ввод — `400`; ошибки в формате ProblemDetails.
- Миграции применяются при старте, аутентификации нет.
