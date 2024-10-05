## [1.0.8] - 2024-10-04
- Added Version Define for URP Enabled
- The Define Tag is marked "ENABLED_UNITY_URP"

## [1.0.7] - 2024-09-12
- Added `VisualElement` extensions:
- `RemoveFrom` extension method to remove a child `VisualElement` from a parent.
- `RemoveClass` extension method to remove CSS classes from a `VisualElement`.

## [1.0.6] - 2024-09-08
### Add RichText Extensions
- Added more extensions methods in:
- `String` extensions
  - `RichText` extensions

## [1.0.5] - 2024-09-04
### Add More UI Toolkit Extensions
- Added ConvertToAlphaNumeric method in:
  - `String` extensions
- Add more extensions classes:
  - `Color` extensions

## [1.0.4] - 2024-09-01
### Add UI Toolkit Extensions
- Add UI Toolkit extensions:
    - `VisualElement` extensions
    - `UQueryBuilder` extensions

## [1.0.3] - 2024-07-29
### Add License and Code Cleanup
- Add License
- Migrate WaitForSeconds method to WaitFor class
- Update Readme

## [1.0.2] - 2024-07-21
### Add Hotkeys and Helpers
- Add WaitFor static class
- Add hotkeys:
    - Save Scene + Project
    - Close Window
    - Compile Project
    - Lock Inspector and Constrain Proportions

## [1.0.1] - 2024-06-24
### Add Conversion Methods
- Added conversion methods between `UnityEngine` and `System.Numerics` vectors and quaternions.
- Adds missing namespaces to some classes

## [1.0.0]
### Initial Release and Additions
- Introduced foundational package contents.

### Added
- `AsyncOperation`, `Task`, and `Enumerable` extenstion methods.
- `RandomPointInAnnulus` with uniform distribution.
- `InRangeOf` with optional angle.

### Improved
- Optimized `GetWaitForSeconds`.

### Other Changes
- Added various extensions and helper methods for vectors, numbers, strings, layers, tasks, enumerables, and more.
- Included `FrameRateLimiter` helper and `LayerMask` extensions classes.
- Updated preprocessor directives and optimized helper methods.
