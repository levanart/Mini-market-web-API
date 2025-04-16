
# 🚀 MyCoolTool

![Version](https://img.shields.io/badge/version-1.0.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)
![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS-lightgrey)

CLI-утилита для людей, которым надоело страдать. Простая, понятная, без лишнего мусора

---

## ⚙️ Установка

### Через .NET CLI:

```bash
dotnet tool install --global MyCoolTool
```

### Или вручную:

```bash
git clone https://github.com/username/MyCoolTool.git
cd MyCoolTool
dotnet build
```

---

## 🛠 Примеры использования

```bash
mycooltool init            # инициализация проекта
mycooltool convert file.md --to=pdf
mycooltool deploy --prod
```

---

## 📋 Команды

| Команда                      | Описание                         |
|-----------------------------|----------------------------------|
| `mycooltool init`           | Создаёт стартовый шаблон         |
| `mycooltool convert`        | Конвертирует файлы               |
| `mycooltool deploy --prod` | Заливает билд в продакшн        |

---

## 🧰 Настройки

Создай файл `mycooltool.config.json` в корне:

```json
{
  "outputPath": "./build",
  "format": "pdf",
  "minify": true
}
```

Или используй переменные окружения:

```bash
MYCOOLTOOL_OUTPUT=./build
```

---

<details>
<summary>📦 Зависимости и внутренняя магия</summary>

- .NET 8
- Spectre.Console для вывода
- Newtonsoft.Json для конфигов
- System.CommandLine для CLI
- И немного шаманства внутри

</details>

---

## 🧑‍💻 Contributing

Pull requests — welcome  
Если нашёл баг или хочешь улучшить что-то — [создай issue](https://github.com/username/MyCoolTool/issues)

---

## 🪪 Лицензия

MIT — [текст тут](./LICENSE)

---

## 👋 Связь

Пиши в телегу: [@yourhandle](https://t.me/yourhandle)
