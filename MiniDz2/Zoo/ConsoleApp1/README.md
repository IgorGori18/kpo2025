# Краткий отчёт по проекту «Zoo Management»

## Реализованный функционал
- **Животные**
    - Добавление / удаление: `AnimalService` → `AnimalsController`
    - Просмотр списка и деталей: `AnimalService.GetAll` / `GetById`
- **Вольеры**
    - Создание / удаление (с проверкой на пустоту): `EnclosureService` → `EnclosuresController`
    - Список и детали
- **Перемещение животных**
    - `AnimalTransferService.TransferAnimal` → `AnimalTransfersController`
    - Генерация события `AnimalMovedEvent`
- **Кормления**
    - Планирование: `FeedingOrganizationService.ScheduleFeeding` → `FeedingsController`
    - Просмотр (с фильтром по выполненным)
    - Отметка выполненным → `FeedingTimeEvent`
- **Статистика**
    - Сводка: общее число животных и свободных вольеров
    - `ZooStatisticsService.GetStatistics` → `StatisticsController`

## Применённые принципы DDD
- **Entities & Value Objects**
    - `Animal`, `Enclosure`, `FeedingSchedule` — сущности с инкапсулированной логикой (методы `MoveToEnclosure`, `MarkCompleted`)
    - `AnimalSpecies`, `AnimalGender`, `AnimalStatus`, `EnclosureType`, `Dimensions` — неизменяемые VO
- **Доменные события**
    - `AnimalMovedEvent`, `FeedingTimeEvent` (наследники `DomainEvent`)
    - Публикация через `IDomainEventPublisher` → `ConsoleDomainEventPublisher`
- **Repositories**
    - Интерфейсы в `Application/Interfaces` и in‑memory реализации в `Infrastructure/Repositories`

## Соблюдение Clean Architecture
- **Слои и зависимости:**
    - **Domain** (модель) не зависит ни от чего
    - **Application** (use‑case) зависит только от Domain
    - **Infrastructure** реализует контракты Application
    - **Presentation** (Web API) использует только Application
- **Инверсия зависимостей:**
    - Все репозитории и издатель событий регистрируются через DI (`Program.cs`)
- **Изоляция бизнес‑логики:**
    - Контроллеры делегируют работу сервисам, не содержат «if» и циклов бизнес‑уровня
