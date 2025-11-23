# 🏋️ מערכת ניהול חדר כושר - Gym Management API

## 📋 תיאור הפרויקט
מערכת ניהול מקיפה לחדר כושר המאפשרת ניהול מנויים, מאמנים ושיעורים קבוצתיים.  
המערכת בנויה כ-RESTful API עם ASP.NET Core Web API.

---

## 🎯 מטרת המערכת
- ניהול רשימת חברים (מנויים) בחדר הכושר
- ניהול צוות המאמנים והתחומים שלהם
- ארגון שיעורים קבוצתיים ומעקב אחר תפוסה
- מעקב אחר סטטוס חברות ופעילות

---

## 🗂️ ישויות (Entities)

### 1️⃣ Members (חברים/מנויים)
מייצג את חברי חדר הכושר.

**שדות:**
- `Id` - מזהה ייחודי
- `FirstName` - שם פרטי
- `LastName` - שם משפחה
- `Email` - דוא"ל
- `Phone` - טלפון
- `MembershipType` - סוג מנוי (חודשי/שנתי)
- `StartDate` - תאריך התחלת מנוי
- `IsActive` - האם החבר פעיל

### 2️⃣ Trainers (מאמנים)
מייצג את צוות המאמנים בחדר הכושר.

**שדות:**
- `Id` - מזהה ייחודי
- `FirstName` - שם פרטי
- `LastName` - שם משפחה
- `Email` - דוא"ל
- `Phone` - טלפון
- `Specialization` - התמחות (יוגה, פילאטיס, כושר וכו')
- `YearsOfExperience` - שנות ניסיון
- `IsAvailable` - האם זמין

### 3️⃣ Classes (שיעורים קבוצתיים)
מייצג את השיעורים הקבוצתיים המוצעים.

**שדות:**
- `Id` - מזהה ייחודי
- `ClassName` - שם השיעור
- `TrainerId` - מזהה המאמן המלמד
- `DayOfWeek` - יום בשבוע
- `StartTime` - שעת התחלה
- `Duration` - משך השיעור (בדקות)
- `MaxParticipants` - מספר משתתפים מקסימלי
- `CurrentParticipants` - מספר משתתפים נוכחי

---

## 🔗 API Endpoints

### Members (חברים)

| שיטה | נתיב | תיאור |
|------|------|-------|
| `GET` | `/api/members` | שליפת כל החברים |
| `GET` | `/api/members/{id}` | שליפת חבר לפי מזהה |
| `POST` | `/api/members` | הוספת חבר חדש |
| `PUT` | `/api/members/{id}` | עדכון פרטי חבר |
| `DELETE` | `/api/members/{id}` | מחיקת חבר |
| `GET` | `/api/members/active` | **שליפת רק חברים פעילים** ⭐ |

---

### Trainers (מאמנים)

| שיטה | נתיב | תיאור |
|------|------|-------|
| `GET` | `/api/trainers` | שליפת כל המאמנים |
| `GET` | `/api/trainers/{id}` | שליפת מאמן לפי מזהה |
| `POST` | `/api/trainers` | הוספת מאמן חדש |
| `PUT` | `/api/trainers/{id}` | עדכון פרטי מאמן |
| `DELETE` | `/api/trainers/{id}` | מחיקת מאמן |
| `GET` | `/api/trainers/specialization/{type}` | **חיפוש מאמנים לפי התמחות** ⭐ |

---

### Classes (שיעורים)

| שיטה | נתיב | תיאור |
|------|------|-------|
| `GET` | `/api/classes` | שליפת כל השיעורים |
| `GET` | `/api/classes/{id}` | שליפת שיעור לפי מזהה |
| `POST` | `/api/classes` | הוספת שיעור חדש |
| `PUT` | `/api/classes/{id}` | עדכון פרטי שיעור |
| `DELETE` | `/api/classes/{id}` | מחיקת שיעור |
| `GET` | `/api/classes/day/{dayOfWeek}` | **שליפת שיעורים לפי יום בשבוע** ⭐ |

---

## 🛠️ טכנולוגיות

- **Framework:** ASP.NET Core Web API
- **Language:** C#
- **Architecture:** RESTful API
- **Data Storage:** In-Memory Lists (לצורך פיתוח)
- **Documentation:** Swagger/OpenAPI

---

## 🚀 הרצת הפרויקט

### דרישות מקדימות
- .NET 6.0 SDK או גרסה חדשה יותר
- Visual Studio 2022 או VS Code

### הוראות הפעלה
1. שכפל את הפרויקט:
```bash
   git clone https://github.com/y0534151365-hash/GymManagementAPI.git
```

2. פתח את הפרויקט ב-Visual Studio

3. הרץ את הפרויקט:
   - לחץ F5 או על כפתור ההרצה הירוק

4. הדפדפן ייפתח עם Swagger UI בכתובת:
```
   https://localhost:XXXX/swagger
```

---

## 📝 דוגמאות שימוש

### הוספת חבר חדש
```json
POST /api/members
{
  "firstName": "דני",
  "lastName": "כהן",
  "email": "danny@example.com",
  "phone": "050-1234567",
  "membershipType": "שנתי",
  "startDate": "2024-01-01",
  "isActive": true
}
```

### שליפת מאמנים לפי התמחות
```
GET /api/trainers/specialization/יוגה
```

### שליפת שיעורים ביום ראשון
```
GET /api/classes/day/ראשון
```

---

## 📌 הערות חשובות

- ⚠️ המערכת כרגע משתמשת באחסון זיכרון זמני (In-Memory)
- 🔄 הנתונים נמחקים בכל הפעלה מחדש של השרת
- 🔜 בעתיד: חיבור למסד נתונים (SQL Server / Entity Framework)

---

## 👨‍💻 מפתח
**שם שלך** - פרויקט קורס Web API

---

## 📅 תאריך יצירה
נובמבר 2024

---

## 📜 רישיון
פרויקט לימודי - ללא רישיון מסחרי
