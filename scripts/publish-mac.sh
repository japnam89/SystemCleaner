#!/usr/bin/env bash
# Publish self-contained single-file build for macOS (x64/arm64)
# Usage: ./scripts/publish-mac.sh [rid=osx-x64]
set -euo pipefail
RID=${1:-osx-x64}
CONFIG=${2:-Release}
PROJECT=SystemCleaner.csproj
OUT=artifacts/${RID}
rm -rf "$OUT"
mkdir -p "$OUT"

echo "Publishing $PROJECT for $RID ($CONFIG)..."

dotnet publish "$PROJECT" -c "$CONFIG" -r "$RID" --self-contained true /p:PublishSingleFile=true -o "$OUT"

if [ $? -ne 0 ]; then
  echo "dotnet publish failed" >&2
  exit 1
fi

# Create a simple .app bundle wrapper
APPNAME="AI Smart Cleaner"
APPDIR="$OUT/${APPNAME}.app"
mkdir -p "$APPDIR/Contents/MacOS"
mkdir -p "$APPDIR/Contents/Resources"

# move single-file executable into MacOS
EXE=$(ls "$OUT" | head -n 1)
if [ -z "$EXE" ]; then
  echo "No published output found" >&2
  exit 1
fi
mv "$OUT/$EXE" "$APPDIR/Contents/MacOS/SystemCleaner"
chmod +x "$APPDIR/Contents/MacOS/SystemCleaner"

cat > "$APPDIR/Contents/Info.plist" <<EOF
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
  <key>CFBundleName</key>
  <string>${APPNAME}</string>
  <key>CFBundleDisplayName</key>
  <string>${APPNAME}</string>
  <key>CFBundleExecutable</key>
  <string>SystemCleaner</string>
  <key>CFBundleIdentifier</key>
  <string>tech.japnam.aismartcleaner</string>
  <key>CFBundleVersion</key>
  <string>2.5.2</string>
  <key>CFBundlePackageType</key>
  <string>APPL</string>
  <key>LSMinimumSystemVersion</key>
  <string>10.12</string>
</dict>
</plist>
EOF

# Create a dmg if on macOS
if command -v hdiutil >/dev/null 2>&1; then
  DMG="artifacts/SystemCleaner-mac-${RID}-$(date +%Y%m%d-%H%M%S).dmg"
  echo "Creating DMG $DMG..."
  hdiutil create -volname "AI Smart Cleaner" -srcfolder "$APPDIR" -ov -format UDZO "$DMG"
  echo "DMG created: $DMG"
else
  echo "hdiutil not available; created .app bundle at $APPDIR"
fi

echo "Done. Output: $OUT"