# Cinema App

<p align="start">
   <img src="https://img.shields.io/badge/v9.0.8-NETFrameworkCore.Sqlite-blue" alt=".NETFramework">
  <img src="https://img.shields.io/badge/v0.1.1-FFImageLoadingCompat.Svg-green" alt=".NETFramework">
  <img src="https://img.shields.io/badge/License-MIT-suggess" alt="License">
</p>

Мобильное приложение для поиска и отображения информации о кинофильмах, позволяет искать кинофильмы по
одному или нескольким критериям и отображать информацию по выбранному кинофильму.

## 🛠️ Стек технологий
- MAUI
- C#
- Entity Framework Core
- SQLite
- NUnit
  
## 📊 Архитектура

- Onion Architecture
- MVVM

# 🧾 Структура проекта
- CinemaApp (Приложение MAUI, клиентская часть)
- CinemaApp.Core (Бизнес-логика)
- CinemaApp.Infrastructure (Обработки базы данных)
- СinemaApp.Domain (Сущности)
- CinemaApp.Test (Тестирование)

  # SQL-Script поиска
  1) При поиски только по жанрам
  <pre>
  <code>
  SELECT DISTINCT fl.*
  FROM Films fl
  LEFT JOIN FilmGenre fg ON fl.Id = fg.FilmsId
  WHERE 
      fg.GenresId IN (@numbers);
  </code>
  </pre>
  2) При поски по названию фильма, актера и жанрам
  <pre>
  <code>
  SELECT DISTINCT fl.*
  FROM Films fl
  LEFT JOIN ActorFilm af ON fl.Id = af.FilmsId 
  LEFT JOIN Actors ac ON af.ActorsId = ac.Id 
  LEFT JOIN FilmGenre fg ON fl.Id = fg.FilmsId
  WHERE 
      fl.Name LIKE '%@surchStr%'
      OR ac.Name LIKE '%@surchStr%'
      OR fg.GenresId IN (@numbers);
  </code>
  </pre>
  
  # Тестовые данные в БД
  <p>Заполнение тестовыми данными бд</p>
  <p>При первом запуске в файле <Code>CinemaApp.MainPage.xaml.cs</code> раскоментировать 19 строчку.</p>
  <p>При первом запуске в файле <Code>CinemaApp.Infrastructure.Persistence.ApplicationDbContext.cs</code> раскоментировать 19 строчку.</p>

  # Preview
  <table cellspacing="0" cellpadding="0">
    <tr>
      <td>
      Главная страница
      <img width="378" height="883" alt="image" src="https://github.com/user-attachments/assets/a75f307e-718f-4b26-ba56-e5cc74c05a62" />
      </td>
      <td>
      Страница с деталями поиска
      <img width="382" height="875" alt="image" src="https://github.com/user-attachments/assets/9888c571-0173-4ac8-bac7-2c050a9f6b51" />
      </td>
    </tr>
  </table>
